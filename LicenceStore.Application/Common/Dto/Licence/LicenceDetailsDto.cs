namespace LicenceStore.Application.Common.Dto.Licence;

public record LicenceDetailsDto(string Name, DateTime StartDate, DateTime EndDate, string Vendor, string Category, string Type, string? Owner, bool IsSold, bool IsBought, double Price, string Img, string Description);