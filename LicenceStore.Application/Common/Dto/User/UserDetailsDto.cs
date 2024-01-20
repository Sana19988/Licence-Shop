namespace LicenceStore.Application.Common.Dto.User;

public record UserDetailsDto(string? FirstName, string? LastName, string? Email, string? NormalizedEmail,
    string? UserName, string? NormalizedUserName, IEnumerable<string?> Licences, List<string> Roles);