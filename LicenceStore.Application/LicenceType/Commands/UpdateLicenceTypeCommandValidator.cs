using FluentValidation;
using LicenceStore.Application.Common.Validators.LicenceType;

namespace LicenceStore.Application.LicenceType.Commands;

public class UpdateLicenceTypeCommandValidator : AbstractValidator<UpdateLicenceTypeCommand>
{
    public UpdateLicenceTypeCommandValidator()
    {
        RuleFor(licence => licence.LicenceType).SetValidator(new UpdateLicenceTypeDtoValidator());
    }
    
}