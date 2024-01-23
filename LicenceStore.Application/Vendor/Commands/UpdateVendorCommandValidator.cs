using FluentValidation;
using LicenceStore.Application.Common.Validators.Vendor;

namespace LicenceStore.Application.Vendor.Commands;

public class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand>
{
    public UpdateVendorCommandValidator()
    {
        RuleFor(v => v.Vendor).SetValidator(new UpdateVendorDtoValidator());
    }
}