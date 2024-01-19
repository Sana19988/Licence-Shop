using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Domain.Entities;

namespace LicenceStore.Application.Common.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(CreateUserDto user, List<string> roles);
    Task UpdateUserAsync(ApplicationUser user);
    Task DeleteUserAsync(ApplicationUser user);
    Task<ApplicationUser?> GetUserAsync(string id);
    public List<ApplicationUser> GetAllUsers();
    Task<ApplicationUser?> GetUserByEmailAsync(string id);
    Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
}
