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

public class UpdateLicenceDtoValidator : AbstractValidator<UpdateLicenceDto>
{

    public UpdateLicenceDtoValidator()
    {
        RuleFor(licence => licence.Name)
            .MaximumLength(512)
            .MinimumLength(3)
            .NotEmpty()
            .WithMessage("Name should be between 3 and 512 characters long");
        RuleFor(licence => licence.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(2000)
            .WithMessage("Price should be greater than or equal to 2000");
        RuleFor(licence => licence.IsSold)
            .NotEmpty()
            .Must(l =>
            {
                if (l == true) return true;
                return l == false;
            });
    }
    
}