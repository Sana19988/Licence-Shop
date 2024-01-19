using LicenceStore.Application.Common.Constants;
using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Application.Common.Interfaces;
using MediatR;

namespace LicenceStore.Application.Administrator.Commands.CreateAdministratorCommand;

public record CreateAdministratorCommand(CreateUserDto Admin) : IRequest;

public class CreateAdminHandler : IRequestHandler<CreateAdministratorCommand>
{
    private readonly IUserService _userService;

    public CreateAdminHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(CreateAdministratorCommand request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.Admin,
            new List<string> { LicenceStoreAuthorization.Administrator });
    }
}
