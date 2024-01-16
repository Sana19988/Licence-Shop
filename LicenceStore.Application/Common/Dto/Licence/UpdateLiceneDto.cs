namespace LicenceStore.Application.Common.Dto.Licence;

public record UpdateLicenceDto(
    string LicenceId,
    string? Name,
    string? Vendor,
    string? Category,
    string? Type,
    string? Owner,
    bool? IsSold,
    bool? IsBought,
    double? Price,
    string? Img,
    string? Description
);