using AutoMapper;
using LicenceStore.Application.Common.Exceptions;
using LicenceStore.Application.Common.Interfaces;
using MediatR;

namespace LicenceStore.Application.Users.Commands;

public record DeleteUserCommand(string UserId) : IRequest<string>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(request.UserId);
        if (user == null)
            throw new NotFoundException("User not found");

        await _userService.DeleteUserAsync(user);
        return "User successfully deleted!";
    }
}