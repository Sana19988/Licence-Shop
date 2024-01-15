using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Car.Commands;

public record CreateCarCommand(string Name) : IRequest;

public class CreateCarHandler : IRequestHandler<CreateCarCommand>
{
    public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        // var vendor = new Vendor("Audi");
        // await vendor.SaveAsync(cancellation: cancellationToken);
        //
        // var data = new RenatalCar.Domain.Entities.Car(request.Name)
        //     .AddYearProduction(1985)
        //     .AddVendor(new One<Vendor>(vendor));
        // await data.SaveAsync(cancellation: cancellationToken);
    }
}
