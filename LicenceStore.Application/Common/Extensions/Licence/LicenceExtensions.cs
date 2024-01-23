using LicenceStore.Application.Licence.Queries;
using MongoDB.Entities;

namespace LicenceStore.Application.Common.Extensions.Licence;

public static class LicenceExtensions
{
    public static PagedSearch<Domain.Entities.Licence, Domain.Entities.Licence> ApplyFilters(
        this PagedSearch<Domain.Entities.Licence, Domain.Entities.Licence> query, GetPagedListLicenceQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.SearchQuery))
        {
            query = (PagedSearch<Domain.Entities.Licence>)query.Match(c => c.Name.Contains(filters.SearchQuery));
        }

        return query;
    }
}