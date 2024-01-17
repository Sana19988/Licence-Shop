using FluentValidation;
using LicenceStore.Application.Common.Dto.LicenceType;

namespace LicenceStore.Application.Common.Validators.LicenceType;

public class CreateLicenceTypeDtoValidator : AbstractValidator<CreateLicenceTypeDto>
{
    public CreateLicenceTypeDtoValidator()
    {
        RuleFor(licence => licence.Name)
            .MaximumLength(512)
            .MinimumLength(3)
            .NotEmpty()
            .WithMessage("Name should be between 3 and 512 characters long");
        RuleFor(licence => licence.Active)
            .NotEmpty();
    }
    
}