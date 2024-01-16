using FluentValidation;
using LicenceStore.Application.Common.Validators.Licence;

namespace LicenceStore.Application.Licence.Commands;

public class UpdateLicenceCommandValidator : AbstractValidator<UpdateLicenceCommand>
{
    public UpdateLicenceCommandValidator()
    {
        RuleFor(licence => licence.Licence).SetValidator(new UpdateLicenceDtoValidator());
    }
    
}