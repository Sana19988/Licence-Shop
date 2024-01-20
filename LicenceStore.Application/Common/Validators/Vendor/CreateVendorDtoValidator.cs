using FluentValidation;
using LicenceStore.Application.Common.Dto.Vendor;

namespace LicenceStore.Application.Common.Validators.Vendor;

public class CreateVendorDtoValidator : AbstractValidator<CreateVendorDto>
{
    public CreateVendorDtoValidator()
    {
        RuleFor(v => v.Name)
            .MinimumLength(3)
            .MaximumLength(512)
            .NotEmpty()
            .WithMessage("Name should be between 3 and 512 characters long");
        RuleFor(v => v.Active)
            .NotEmpty();
    }
}