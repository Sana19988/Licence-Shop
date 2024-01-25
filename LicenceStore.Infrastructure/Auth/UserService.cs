using System.Security.Claims;
using AspNetCore.Identity.MongoDbCore.Models;
using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Application.Common.Interfaces;
using LicenceStore.Domain.Entities;
using LicenceStore.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace LicenceStore.Infrastructure.Auth;

public class UserService : IUserService
{
    private readonly ApplicationUserManager _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    
    public UserService(ApplicationUserManager userManager, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task CreateUserAsync(CreateUserDto user, List<string> roles)
    {
        var alreadyExist = await _userManager.FindByEmailAsync(user.Email);
        
        if (alreadyExist != null)
            return;

        var newUser = new ApplicationUser
        {
            Email = user.Email,
            UserName = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Licences = new List<Licence>(),
            Roles = new List<string>()
        };

        if (roles.Contains("Customer"))
        {
            newUser.Balance = 10000;
        }

        try
        {
            foreach (var role in roles)
            {
                var roleName = role.ToUpper();
                
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var roleResult = await _roleManager.CreateAsync(new ApplicationRole { Name = roleName });
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception("Failed role creation.");
                    }
                }
            }

            
            newUser.Claims.Add(new MongoClaim { Type = ClaimTypes.Email, Value = user.Email });
            newUser.Claims.AddRange(roles.Select(userRole => new MongoClaim
            {
                Type = ClaimTypes.Role, Value = userRole
            }));

            var result = await _userManager.CreateAsync(newUser);

            if (!result.Succeeded)
            {
                throw new AuthException("Could not create a new user",
                    new { Errors = result.Errors.ToList() });
            }

            var rolesResult = await _userManager.AddToRolesAsync(newUser,
                roles.Select(nr => nr.ToUpper()));

            if (!rolesResult.Succeeded)
            {
                await _userManager.DeleteAsync(newUser);

                throw new AuthException("Could not add roles to user",
                    new { Errors = rolesResult.Errors.ToList() });
            }
            
            var newRoles = await _userManager.GetRolesAsync(newUser);
            newUser.Roles.AddRange(newRoles);
            await _userManager.UpdateAsync(newUser);

        }
        catch (Exception e)
        {
            await _userManager.DeleteAsync(newUser);

            throw new AuthException("Could not create a new user",
                e);
        }
    }
    
    private async Task RollbackUserCreationAsync(ApplicationUser user, List<IdentityError> errors)
    {
        await _userManager.DeleteAsync(user);
        throw new AuthException("Could not complete user creation", new { Errors = errors });
    }
    
    public Task UpdateUserAsync(ApplicationUser user) => _userManager.UpdateAsync(user);

    public Task DeleteUserAsync(ApplicationUser user) => _userManager.DeleteAsync(user);

    public Task<ApplicationUser?> GetUserAsync(string id) => _userManager.FindByIdAsync(id);
    public List<ApplicationUser> GetAllUsers() => _userManager.Users.ToList();

    public Task<ApplicationUser?> GetUserByEmailAsync(string id) => _userManager.FindByEmailAsync(id);
    public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName) => _userManager.IsInRoleAsync(user,
        roleName);
}
