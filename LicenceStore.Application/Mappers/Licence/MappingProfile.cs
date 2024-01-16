using AutoMapper;
using LicenceStore.Application.Common.Dto.Licence;

namespace LicenceStore.Application.Mappers.Licence;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLicenceDto, LicenceStore.Domain.Entities.Licence>().ReverseMap();
        CreateMap<UpdateLicenceDto, LicenceStore.Domain.Entities.Licence>().ReverseMap();
        CreateMap<LicenceStore.Domain.Entities.Licence, Task<LicenceDetailsDto>>().ConstructUsing(x => GetLicenceDetails(x));
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
            licence.IsBought,
            licence.Price,
            licence.Img,
            licence.Description
        );
    }
    
    // TODO DODATI ZA PAGINACIJU
    
}