using LicenceStore.Application.Vendor.Queries;
using MongoDB.Entities;

namespace LicenceStore.Application.Common.Extensions.Vendor;

public static class VendorExtensions
{
    public static PagedSearch<Domain.Entities.Vendor, Domain.Entities.Vendor> ApplyFilters(this PagedSearch<Domain.Entities.Vendor, Domain.Entities.Vendor> query, GetPagedListVendorQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.SearchQuery))
        {
            query = (PagedSearch<Domain.Entities.Vendor>)query.Match(x => x.Name.Contains(filters.SearchQuery));
        }        
        
        return query;
    }
}