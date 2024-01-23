namespace LicenceStore.Application.Common.Dto.Category;

public record CategoryPagedListDto(List<CategoryDetailsDto> Categories, PaginationDto Pagination)
{
    internal CategoryPagedListDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }

}