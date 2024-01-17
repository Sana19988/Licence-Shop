using AutoMapper;
using LicenceStore.Application.Common.Dto.Category;

namespace LicenceStore.Application.Mappers.Category;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryDto, LicenceStore.Domain.Entities.Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, LicenceStore.Domain.Entities.Category>().ReverseMap();
        CreateMap<LicenceStore.Domain.Entities.Category, CategoryDetailsDto>().ConstructUsing(cat => GetCategoryDetails(cat));
    }

    private static CategoryDetailsDto GetCategoryDetails(Domain.Entities.Category category)
    {
        return new CategoryDetailsDto(category.Name, category.Active);
    }
    
    // TODO Paginacija from previous
}