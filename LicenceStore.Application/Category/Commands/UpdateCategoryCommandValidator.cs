using FluentValidation;
using LicenceStore.Application.Common.Validators.Category;

namespace LicenceStore.Application.Category.Commands;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(cat => cat.Category).SetValidator(new UpdateCategoryDtoValidator());
    }
    
}