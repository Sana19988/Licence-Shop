namespace LicenceStore.Application.Common.Dto.Licence;

public record LicenceDetailsDto(string Name, DateTime StartDate, DateTime EndDate, string Vendor, string Category, string Type, string? Owner, bool IsSold, double Price, string? Sold, string? Bought, string Img, string Description);