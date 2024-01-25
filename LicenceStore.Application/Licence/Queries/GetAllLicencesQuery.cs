using AutoMapper;
using LicenceStore.Application.Common.Dto.Licence;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Licence.Queries;

public record GetAllLicencesQuery : IRequest<LicenceListDto>;

public class GetAllLicencesQueryHandler : IRequestHandler<GetAllLicencesQuery, LicenceListDto>
{
    private readonly IMapper _mapper;

    public GetAllLicencesQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<LicenceListDto> Handle(GetAllLicencesQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<LicenceListDto>(await DB.Find<Domain.Entities.Licence>()
            .ExecuteAsync(cancellation: cancellationToken));
    }
}