using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Order.Commands;

public record DeleteOrderCommand(string OrderId) : IRequest<string>;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, string>
{
    public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Order>(o => o.ID != null && o.ID.Equals(request.OrderId),
            cancellation: cancellationToken);
        return "Order successfully deleted!";
    }
}