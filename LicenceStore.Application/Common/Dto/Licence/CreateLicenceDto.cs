namespace LicenceStore.Application.Common.Dto.Licence;

public record CreateLicenceDto(
    string Name,
    DateTime StartDate,
    DateTime EndDate,
    string VendorId,
    string CategoryId,
    string TypeId,
    string OwnerId,
    bool IsSold,
    double Price,
    string Img,
    string Description
);