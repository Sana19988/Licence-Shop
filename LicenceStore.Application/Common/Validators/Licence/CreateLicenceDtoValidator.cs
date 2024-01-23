using FluentValidation;
using LicenceStore.Application.Common.Dto.Licence;

namespace LicenceStore.Application.Common.Validators.Licence;

// checking for: string Name,
//      DateTime StartDate,
//      DateTime EndDate,
//      string VendorId,
//      string CategoryId,
//      string TypeId,
//      string OwnerId,
//      bool IsSold,
//      double Price,
//      string Img,
//      string Description

public class CreateLicenceDtoValidator : AbstractValidator<CreateLicenceDto>
{
    public CreateLicenceDtoValidator()
    {
        RuleFor(licence => licence.Name)
            .MaximumLength(512)
            .MinimumLength(3)
            .NotEmpty()
            .WithMessage("Name should be between 3 and 512 characters long");
        RuleFor(licence => licence)
            .Must(BeValidDate)
            .WithMessage("Start date should be greater than now and end date should be greater than start");
        RuleFor(licence => licence.VendorId)
            .NotEmpty();
        RuleFor(licence => licence.CategoryId)
            .NotEmpty();
        RuleFor(licence => licence.TypeId)
            .NotEmpty();
        RuleFor(licence => licence.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(2000)
            .WithMessage("Price should be greater than or equal to 2000");
        RuleFor(licence => licence.Img)
            .NotEmpty();
    }

    private static bool BeValidDate(CreateLicenceDto licenceDto)
    {
        return licenceDto.StartDate > DateTime.UtcNow && licenceDto.EndDate > licenceDto.StartDate;
    }
}