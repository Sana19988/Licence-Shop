using FluentValidation;
using LicenceStore.Application.Common.Dto.User;

namespace LicenceStore.Application.Common.Validators.User;

// checking for: string FirstName,
//              string LastName, 
//              string Email

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(u => u.FirstName)
            .MinimumLength(3)
            .MaximumLength(512)
            .WithMessage("First name should be between 3 and 512 characters long");
        
        RuleFor(u => u.LastName)
            .MinimumLength(3)
            .MaximumLength(512)
            .WithMessage("Last name should be between 3 and 512 characters long");

        RuleFor(u => u.Email)
            .EmailAddress();
    }
}