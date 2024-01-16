using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.LicenceType.Commands;

public record DeleteLicenceTypeCommand(string LicenceTypeId) : IRequest<string>;

public class DeleteLicenceTypeCommandHandler : IRequestHandler<DeleteLicenceTypeCommand, string>
{
    public async Task<string> Handle(DeleteLicenceTypeCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.LicenceType>(lic => lic.ID != null
            && lic.Equals(request.LicenceTypeId),
            cancellation: cancellationToken);

        return "LicenceType successfully deleted!";
    }
}