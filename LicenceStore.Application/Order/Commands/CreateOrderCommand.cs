using LicenceStore.Application.Common.Dto.Order;
using LicenceStore.Application.Common.Exceptions;
using LicenceStore.Application.Common.Interfaces;
using LicenceStore.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Order.Commands;

public record CreateOrderCommand(CreateOrderDto Order) : IRequest<string>;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
{
    private readonly IUserService _userService;
    
    public CreateOrderCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var orderCode = new Random().Next(1, 1000000000);

            var customer = await GetCustomerAsync(request.Order.CustomerId);

            if (customer == null)
                throw new NotFoundException("Customer not found");

            var licences = await GetLicencesAsync(request.Order.LicenceIds, cancellationToken);

            var order = new Domain.Entities.Order
            {
                OrderCode = orderCode,
                Customer = customer,
                Licences = licences,
                TotalPrice = 0,
                Status = "Approved",
                Active = true
            };

            order.CalculateTotalPrice();
            
            await UpdatesalesmanBalancesAsync(licences);

            if (order.TotalPrice > customer.Balance)
            {
                order.Status = "Rejected";
                order.Active = false;
            }
            else
            {
                customer.Balance -= order.TotalPrice;
                customer.Licences.AddRange(licences);
            }

            await _userService.UpdateUserAsync(customer);

            await order.SaveAsync(cancellation: cancellationToken);

            return "Order was successfully created";
        }
        catch (Exception ex)
        {
            return $"Error creating order: {ex.Message}";
        }
    }

    private async Task<ApplicationUser?> GetCustomerAsync(string customerId)
    {
        return await _userService.GetUserAsync(customerId);
    }

    private async Task<List<Domain.Entities.Licence>> GetLicencesAsync(List<string> licenceIds, CancellationToken cancellationToken)
    {
        var licences = new List<Domain.Entities.Licence>();

        foreach (var item in licenceIds)
        {
            var licence = await DB.Find<Domain.Entities.Licence>().OneAsync(item, cancellation: cancellationToken);

            if (licence == null)
            {
                throw new Exception($"Licence with ID {item} not found");
            }

            licences.Add(licence);
        }

        return licences;
    }

    private async Task UpdatesalesmanBalancesAsync(List<Domain.Entities.Licence> licences)
    {
        foreach (var licence in licences.Where(licence => licence.Owner.Email != null))
        {
            if (licence.Owner.Email == null) continue;
            var salesman = await _userService.GetUserByEmailAsync(licence.Owner.Email);

            if (salesman == null) continue;
            salesman.Balance += licence.Price;
            await _userService.UpdateUserAsync(salesman);
        }
    }
}