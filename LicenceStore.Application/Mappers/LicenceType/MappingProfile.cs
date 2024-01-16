using AutoMapper;
using LicenceStore.Application.Common.Dto.LicenceType;

namespace LicenceStore.Application.Mappers.LicenceType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLicenceTypeDto, LicenceStore.Domain.Entities.LicenceType>().ReverseMap();
        CreateMap<UpdateLicenceTypeDto, LicenceStore.Domain.Entities.LicenceType>().ReverseMap();
        CreateMap<LicenceStore.Domain.Entities.LicenceType, LicenceTypeDetailsDto>().ConstructUsing(x => GetLicenceTypeDetails(x));
    }

    private static LicenceTypeDetailsDto GetLicenceTypeDetails(Domain.Entities.LicenceType type)
    {
        return new LicenceTypeDetailsDto(type.Name, type.Active);
    }
    
    // TODO Paginacija i ovde 
    
}