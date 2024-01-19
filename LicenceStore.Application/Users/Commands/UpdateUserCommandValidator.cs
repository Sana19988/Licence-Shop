using FluentValidation;
using LicenceStore.Application.Common.Validators.User;

namespace LicenceStore.Application.Users.Commands;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(u => u.User).SetValidator(new UpdateUserDtoValidator());
    }
}