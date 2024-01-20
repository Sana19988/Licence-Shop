using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Vendor.Commands;

public record DeleteVendorCommand(string VendorId) : IRequest<string>;

public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, string>
{
    public async Task<string> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Vendor>(v => v.ID != null && v.ID.Equals(request.VendorId),
            cancellation: cancellationToken);
        return "Vendor successfully deleted!";
    }
}