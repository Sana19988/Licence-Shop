using LicenceStore.Domain.Entities;

namespace LicenceStore.Application.Common.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(string emailAddress, List<string> roles);
    Task<ApplicationUser?> GetUserAsync(string id);
    Task<ApplicationUser?> GetUserByEmailAsync(string id);
    Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
}
