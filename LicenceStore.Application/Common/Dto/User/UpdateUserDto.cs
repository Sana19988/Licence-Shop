namespace LicenceStore.Application.Common.Dto.User;

public record UpdateUserDto(string UserId, string? FirstName, string? LastName, string? Email);