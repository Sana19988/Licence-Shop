using AutoMapper;
using LicenceStore.Application.Common.Dto.Licence;
using LicenceStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Licence.Commands;

public record UpdateLicenceCommand(UpdateLicenceDto Licence) : IRequest<string>;

public class UpdateLicenceCommandHandler : IRequestHandler<UpdateLicenceCommand, string>
{
    private readonly IMapper _mapper;

    public UpdateLicenceCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<string> Handle(UpdateLicenceCommand request, CancellationToken cancellationToken)
    {
        var licence = await DB.Find<Domain.Entities.Licence>()
            .OneAsync(request.Licence.LicenceId, cancellation: cancellationToken);

        if (licence == null)
        {
            throw new NotFoundException("Licence not found");
        }

        _mapper.Map(request.Licence, licence);
        await licence.SaveAsync(cancellation: cancellationToken);

        return "Licence successfully updated!";
    }
}