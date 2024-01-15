using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Licence.Commands;

public record DeleteLicenceCommand(string LicenceId) : IRequest<string>;

public class DeleteLicenceCommandHandler : IRequestHandler<DeleteLicenceCommand, string>
{
    public async Task<string> Handle(DeleteLicenceCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Licence>(
            licence => licence.ID != null && licence.ID.Equals(request.LicenceId), cancellation: cancellationToken);

        return "Licence successfully deleted!";
    }
}