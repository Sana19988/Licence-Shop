using FluentValidation;
using LicenceStore.Application.Common.Validators.LicenceType;
using LicenceStore.Application.Licence.Commands;

namespace LicenceStore.Application.LicenceType.Commands;

public class CreateLicenceTypeCommandValidator : AbstractValidator<CreateLicenceTypeCommand>
{
    public CreateLicenceTypeCommandValidator()
    {
        RuleFor(licence => licence.LicenceType).SetValidator(new CreateLicenceTypeDtoValidator());
    }    
}