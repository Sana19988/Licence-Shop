namespace LicenceStore.Application.Common.Dto.User;

public record UserPagedListDto(List<UserDetailsDto> Users, PaginationDto Pagination)
{
    internal UserPagedListDto AddPagination(PaginationDto paginationDto)
    {
        return this with { Pagination = paginationDto };
    }
}