using FluentValidation;
using LicenceStore.Application.Common.Dto.Order;

namespace LicenceStore.Application.Common.Validators.Order;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(o => o.CustomerId)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(o => o.LicenceIds)
            .Must(list => list.Count >= 1)
            .WithMessage("There must be at least one licence");
    }
    
    private static bool ValidateStringList(IReadOnlyCollection<string>? stringList)
    {
        return stringList != null && stringList.All(str => !string.IsNullOrEmpty(str));
    }
}