using FluentValidation;
using LicenceStore.Application.Common.Validators.Order;

namespace LicenceStore.Application.Order.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.Order).SetValidator(new CreateOrderDtoValidator());
    }
}