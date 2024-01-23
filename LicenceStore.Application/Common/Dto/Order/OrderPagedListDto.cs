namespace LicenceStore.Application.Common.Dto.Order;

public record OrderPagedListDto(List<OrderDetailsDto> Orders, PaginationDto Pagination)
{
    internal OrderPagedListDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
}