using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.LicenceType;

namespace LicenceStore.Application.Mappers.LicenceType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLicenceTypeDto, LicenceStore.Domain.Entities.LicenceType>().ReverseMap();
        CreateMap<UpdateLicenceTypeDto, LicenceStore.Domain.Entities.LicenceType>().ReverseMap();
        CreateMap<LicenceStore.Domain.Entities.LicenceType, LicenceTypeDetailsDto>()
            .ConstructUsing(l => GetLicenceTypeDetails(l));
        CreateMap<IEnumerable<Domain.Entities.LicenceType>, LicenceTypePagedListDto>()
            .ConstructUsing(l => GetLicenceTypePagedList(l));
    }

    private static LicenceTypeDetailsDto GetLicenceTypeDetails(Domain.Entities.LicenceType type)
    {
        return new LicenceTypeDetailsDto(type.Name, type.Active);
    }
    
    private static LicenceTypePagedListDto GetLicenceTypePagedList(IEnumerable<Domain.Entities.LicenceType> types)
    {
        var licenceTypeList = types.Select(GetLicenceTypeDetails).ToList();
        
        return new LicenceTypePagedListDto(licenceTypeList, new PaginationDto(0, 0));
    }
}