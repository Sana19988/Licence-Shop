using LicenceStore.Application.Users.Queries;
using MongoDB.Entities;

namespace LicenceStore.Application.Common.Extensions.User;

public static class UserExtensions
{
    public static PagedSearch<Domain.Entities.ApplicationUser, Domain.Entities.ApplicationUser> ApplyFilters(this PagedSearch<Domain.Entities.ApplicationUser, Domain.Entities.ApplicationUser> query, GetUserPagedListQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.SearchQuery))
        {
            query = (PagedSearch<Domain.Entities.ApplicationUser>)query.Match(x => x.Name!
                    .ToUpper()
                    .Contains(filters.SearchQuery.ToUpper()) ||
                x.Email!
                    .ToUpper()
                    .Contains(filters.SearchQuery.ToUpper()) ||
                x.FirstName!
                    .ToUpper()
                    .Contains(filters.SearchQuery.ToUpper()) ||
                x.LastName!
                    .ToUpper()
                    .Contains(filters.SearchQuery.ToUpper()));
        }

        return query;
    }
}