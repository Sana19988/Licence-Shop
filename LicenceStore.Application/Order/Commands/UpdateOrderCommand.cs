using AutoMapper;
using LicenceStore.Application.Common.Dto.Order;
using LicenceStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Order.Commands;

public record UpdateOrderCommand(UpdateOrderDto Order) : IRequest<string>;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, string>
{
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<string> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await DB.Find<Domain.Entities.Order>()
            .OneAsync(request.Order.OrderId, cancellation: cancellationToken);

        if (order == null)
            throw new NotFoundException("Order not found");

        _mapper.Map(request.Order, order);
        await order.SaveAsync(cancellation: cancellationToken);

        return "Order successfully updated!";
    }
}