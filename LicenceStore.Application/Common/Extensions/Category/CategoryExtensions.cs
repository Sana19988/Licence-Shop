using LicenceStore.Application.Category.Queries;
using MongoDB.Entities;

namespace LicenceStore.Application.Common.Extensions.Category;

public static class CategoryExtensions
{
    public static PagedSearch<Domain.Entities.Category, Domain.Entities.Category> ApplyFilters(
        this PagedSearch<Domain.Entities.Category, Domain.Entities.Category> query, GetPagedListCategoryQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.SearchQuery))
        {
            query = (PagedSearch<Domain.Entities.Category>)query.Match(c => c.Name.Contains(filters.SearchQuery));
        }

        return query;
    }
}