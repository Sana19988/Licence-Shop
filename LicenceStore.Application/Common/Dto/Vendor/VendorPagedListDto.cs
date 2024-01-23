namespace LicenceStore.Application.Common.Dto.Vendor;

public record VendorPagedListDto(List<VendorDetailsDto> Vendors, PaginationDto Pagination)
{
    internal VendorPagedListDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
}