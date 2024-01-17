using FluentValidation;
using LicenceStore.Application.Common.Dto.Category;

namespace LicenceStore.Application.Common.Validators.Category;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(cat => cat.Name)
            .MaximumLength(512)
            .MinimumLength(3)
            .NotEmpty()
            .WithMessage("Name should be between 3 and 512 characters long");
        RuleFor(cat => cat.Active)
            .NotEmpty();
    }
}