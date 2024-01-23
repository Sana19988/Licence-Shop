using AutoMapper;
using LicenceStore.Application.Common.Dto.Licence;
using LicenceStore.Application.Common.Dto.LicenceType;
using LicenceStore.Application.Licence.Queries;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.LicenceType.Queries;

public record GetAllLicenceTypesQuery(): IRequest<List<LicenceTypeDetailsDto>>;

public class GetAllLicenceTypesQueryHandler : IRequestHandler<GetAllLicenceTypesQuery, List<LicenceTypeDetailsDto>>
{
    private readonly IMapper _mapper;

    public GetAllLicenceTypesQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<List<LicenceTypeDetailsDto>> Handle(GetAllLicenceTypesQuery request, CancellationToken cancellationToken)
    {
        var licenceTypes = await DB.Find<LicenceStore.Domain.Entities.LicenceType>()
            .ManyAsync(licenceTypes => licenceTypes.Active == true, cancellationToken);
        
        return _mapper.Map<List<LicenceTypeDetailsDto>>(licenceTypes);
    }
};