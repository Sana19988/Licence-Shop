using FluentValidation;
using LicenceStore.Application.Common.Dto.Vendor;

namespace LicenceStore.Application.Common.Validators.Vendor;

public class UpdateVendorDtoValidator : AbstractValidator<UpdateVendorDto>
{
    public UpdateVendorDtoValidator()
    {
        RuleFor(v => v.Name)
            .MinimumLength(3)
            .MaximumLength(512)
            .WithMessage("Name should be between 3 and 512 characters");
    }
}