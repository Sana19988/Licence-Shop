using FluentValidation;

namespace LicenceStore.Application.Customer.Commands.CreateCustomerCommand;

public class CreateCustomerModelValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerModelValidator()
    {
        RuleFor(x => x.EmailAddress)
            .EmailAddress()
            .NotEmpty();
    }
}
