using FluentValidation;
using LicenceStore.Application.Common.Validators.Vendor;

namespace LicenceStore.Application.Vendor.Commands;

public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
{
    public CreateVendorCommandValidator()
    {
        RuleFor(v => v.Vendor).SetValidator(new CreateVendorDtoValidator());
    }
}