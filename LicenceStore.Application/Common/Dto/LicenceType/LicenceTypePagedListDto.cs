namespace LicenceStore.Application.Common.Dto.LicenceType;

public record LicenceTypePagedListDto(List<LicenceTypeDetailsDto> Types, PaginationDto Pagination)
{
    internal LicenceTypePagedListDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
}