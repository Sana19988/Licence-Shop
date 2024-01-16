using FluentValidation;
using LicenceStore.Application.Common.Dto.Licence;
using LicenceStore.Application.Common.Dto.LicenceType;

namespace LicenceStore.Application.Common.Validators.LicenceType;

public class UpdateLicenceTypeDtoValidator : AbstractValidator<UpdateLicenceTypeDto>
{
    public UpdateLicenceTypeDtoValidator()
    {
        RuleFor(licenceT => licenceT.Name)
            .MaximumLength(512)
            .MinimumLength(3)
            .NotEmpty()
            .WithMessage("Name should be between 3 and 512 characters long");
    }
}