using LicenceStore.Application.Common.Constants;
using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Application.Common.Interfaces;
using MediatR;

namespace LicenceStore.Application.Salesman.Commands;

public record CreateSalesmanCommand(CreateUserDto Salesman) : IRequest;

public class CreateSalesmanCommandHandler : IRequestHandler<CreateSalesmanCommand>
{
    private readonly IUserService _userService;

    public CreateSalesmanCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(CreateSalesmanCommand request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.Salesman,
            new List<string> { LicenceStoreAuthorization.Salesman });
    }
};