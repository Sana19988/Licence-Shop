using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.Licence;

namespace LicenceStore.Application.Mappers.Licence;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLicenceDto, LicenceStore.Domain.Entities.Licence>().ReverseMap();
        CreateMap<UpdateLicenceDto, LicenceStore.Domain.Entities.Licence>().ReverseMap();
        CreateMap<LicenceStore.Domain.Entities.Licence, Task<LicenceDetailsDto>>()
            .ConstructUsing(x => GetLicenceDetails(x));
        CreateMap<IEnumerable<Domain.Entities.Licence>, LicencePagedListDto>()
            .ConstructUsing(l => GetLicencePagedList(l));
    }

    private static async Task<LicenceDetailsDto> GetLicenceDetails(Domain.Entities.Licence licence)
    {
        return new LicenceDetailsDto
        (
            licence.Name,
            licence.StartDate.Date,
            licence.EndDate.Date,
            (await licence.Vendor.ToEntityAsync())!.Name,
            (await licence.Category.ToEntityAsync())!.Name,
            (await licence.Type.ToEntityAsync())!.Name,
            licence.Owner.Email,
            licence.IsSold,
            licence.IsBougth,
            licence.Price,
            licence.Img,
            licence.Description
        );
    }
    
    private static LicencePagedListDto GetLicencePagedList(IEnumerable<Domain.Entities.Licence> licences)
    {
        var licenceList = licences.Select(GetLicenceDetails).ToList();
        
        return new LicencePagedListDto(licenceList, new PaginationDto(0, 0));
    }
    
}