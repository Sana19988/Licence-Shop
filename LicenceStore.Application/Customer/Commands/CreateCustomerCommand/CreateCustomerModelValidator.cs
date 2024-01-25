using FluentValidation;

namespace LicenceStore.Application.Customer.Commands.CreateCustomerCommand;

public class CreateCustomerModelValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerModelValidator()
    {
        RuleFor(x => x.Customer.Email)
            .EmailAddress().WithMessage("Email is required!")
            .NotEmpty().WithMessage("Email address not valid!");
    }
}
