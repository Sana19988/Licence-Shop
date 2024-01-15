using LicenceStore.Application.Common.Dto.Auth;
using LicenceStore.Application.Common.Interfaces;
using MediatR;

namespace LicenceStore.Application.Auth.Commands.BeginLoginCommand;

public record BeginLoginCommand(string EmailAddress) : IRequest<BeginLoginResponseDto>;

public class BeginLoginHandler : IRequestHandler<BeginLoginCommand, BeginLoginResponseDto>
{
    private readonly IAuthService _authService;

    public BeginLoginHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<BeginLoginResponseDto> Handle(BeginLoginCommand request, CancellationToken cancellationToken)
    {
        return await _authService.BeginLoginAsync(request.EmailAddress);
    }
}
