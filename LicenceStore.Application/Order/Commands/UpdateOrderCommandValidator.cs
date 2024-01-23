using FluentValidation;
using LicenceStore.Application.Common.Validators.Order;

namespace LicenceStore.Application.Order.Commands;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(o => o.Order).SetValidator(new UpdateOrderDtoValidator());
    }
}