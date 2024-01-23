using AutoMapper;
using LicenceStore.Application.Common.Dto.Licence;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Licence.Queries;

public record GetAllLicencesQuery : IRequest<List<LicenceDetailsDto>>;

public class GetAllLicencesQueryHandler : IRequestHandler<GetAllLicencesQuery, List<LicenceDetailsDto>>
{
    private readonly IMapper _mapper;

    public GetAllLicencesQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<List<LicenceDetailsDto>> Handle(GetAllLicencesQuery request, CancellationToken cancellationToken)
    {
        var licences = await DB.Find<LicenceStore.Domain.Entities.Licence>()
            .ManyAsync(licence => licence.Active == true, cancellationToken);
        
        return _mapper.Map<List<LicenceDetailsDto>>(licences);
    }
}