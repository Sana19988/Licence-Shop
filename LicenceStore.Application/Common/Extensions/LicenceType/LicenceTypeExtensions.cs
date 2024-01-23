using LicenceStore.Application.LicenceType.Queries;
using MongoDB.Entities;

namespace LicenceStore.Application.Common.Extensions.LicenceType;

public static class LicenceTypeExtensions
{
    public static PagedSearch<Domain.Entities.LicenceType, Domain.Entities.LicenceType> ApplyFilters(
        this PagedSearch<Domain.Entities.LicenceType, Domain.Entities.LicenceType> query, GetPagedListLicenceTypeQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.SearchQuery))
        {
            query = (PagedSearch<Domain.Entities.LicenceType>)query.Match(c => c.Name.Contains(filters.SearchQuery));
        }

        return query;
    }
}