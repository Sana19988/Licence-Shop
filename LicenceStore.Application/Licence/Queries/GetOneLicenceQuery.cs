using AutoMapper;
using LicenceStore.Application.Common.Dto.Licence;
using LicenceStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Licence.Queries;

public record GetOneLicenceQuery(string LicenceId) : IRequest<LicenceDetailsDto>;

public class GetOneLicenceQueryHandler : IRequestHandler<GetOneLicenceQuery, LicenceDetailsDto>
{
    private readonly IMapper _mapper;

    public GetOneLicenceQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<LicenceDetailsDto> Handle(GetOneLicenceQuery request, CancellationToken cancellationToken)
    {
        var licence = await DB.Find<Domain.Entities.Licence>()
            .OneAsync(request.LicenceId, cancellation: cancellationToken);
        if (licence == null)
            throw new NotFoundException("Licence not found");
        return await _mapper.Map<Task<LicenceDetailsDto>>(licence);
    }
}