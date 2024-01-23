using LicenceStore.Application.Order.Queries;
using MongoDB.Entities;

namespace LicenceStore.Application.Common.Extensions.Order;

public static class OrderExtensions
{
    public static PagedSearch<Domain.Entities.Order, Domain.Entities.Order> ApplyFilters(
        this PagedSearch<Domain.Entities.Order, Domain.Entities.Order> query, GetPagedListOrderQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.SearchQuery))
        {
            query = (PagedSearch<Domain.Entities.Order>)query.Match(o => o.OrderCode.Equals(filters.SearchQuery));
        }

        return query;
    }
}