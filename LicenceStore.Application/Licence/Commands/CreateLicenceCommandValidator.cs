using FluentValidation;
using LicenceStore.Application.Common.Validators.Licence;

namespace LicenceStore.Application.Licence.Commands;

public class CreateLicenceCommandValidator : AbstractValidator<CreateLicenceCommand>
{
    public CreateLicenceCommandValidator()
    {
        RuleFor(licence => licence.Licence).SetValidator(new CreateLicenceDtoValidator());
    }
}