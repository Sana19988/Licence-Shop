using FluentValidation;

namespace LicenceStore.Application.Administrator.Commands.CreateAdministratorCommand;

public class CreateAdministratorModelValidator : AbstractValidator<CreateAdministratorCommand>
{
    public CreateAdministratorModelValidator()
    {
        RuleFor(x => x.Admin.Email)
            .EmailAddress()
            .NotEmpty();
    }
}
