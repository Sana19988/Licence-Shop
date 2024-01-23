using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.Category;

namespace LicenceStore.Application.Mappers.Category;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryDto, LicenceStore.Domain.Entities.Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, LicenceStore.Domain.Entities.Category>().ReverseMap();
        CreateMap<LicenceStore.Domain.Entities.Category, CategoryDetailsDto>()
            .ConstructUsing(cat => GetCategoryDetails(cat));
        CreateMap<IEnumerable<Domain.Entities.Category>, CategoryPagedListDto>()
            .ConstructUsing(cat => GetCategoryPagedList(cat));
    }

    private static CategoryDetailsDto GetCategoryDetails(Domain.Entities.Category category)
    {
        return new CategoryDetailsDto(category.Name, category.Active);
    }

    private static CategoryPagedListDto GetCategoryPagedList(IEnumerable<Domain.Entities.Category> categories)
    {
        var categoryList = categories.Select(GetCategoryDetails).ToList();
        
        return new CategoryPagedListDto(categoryList, new PaginationDto(0, 0));
    }
}