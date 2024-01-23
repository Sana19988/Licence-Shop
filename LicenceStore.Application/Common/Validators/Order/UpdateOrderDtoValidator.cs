using FluentValidation;
using LicenceStore.Application.Common.Dto.Order;

namespace LicenceStore.Application.Common.Validators.Order;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(o => o.TotalPrice)
            .NotNull();
        RuleFor(o => o.Status)
            .NotEmpty();
    }
}