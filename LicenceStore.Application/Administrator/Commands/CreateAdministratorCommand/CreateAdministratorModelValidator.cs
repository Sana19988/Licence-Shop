using FluentValidation;

namespace LicenceStore.Application.Administrator.Commands.CreateAdministratorCommand;

public class CreateAdministratorModelValidator : AbstractValidator<CreateAdministratorCommand>
{
    public CreateAdministratorModelValidator()
    {
        RuleFor(x => x.EmailAddress)
            .EmailAddress()
            .NotEmpty();
    }
}
