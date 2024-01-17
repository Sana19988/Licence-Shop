using FluentValidation;
using LicenceStore.Application.Common.Validators.Category;

namespace LicenceStore.Application.Category.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(cat => cat.Category).SetValidator(new CreateCategoryDtoValidator());
    }
}