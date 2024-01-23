namespace LicenceStore.Application.Common.Dto.Licence;

public record LicencePagedListDto(List<Task<LicenceDetailsDto>> Licences, PaginationDto Pagination)
{
    internal LicencePagedListDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
}