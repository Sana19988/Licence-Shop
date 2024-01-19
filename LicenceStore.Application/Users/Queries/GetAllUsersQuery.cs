using AutoMapper;
using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Application.Common.Interfaces;
using MediatR;

namespace LicenceStore.Application.Users.Queries;

public record GetAllUsersQuery() : IRequest<UserListDto>;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UserListDto>
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }
    
    public Task<UserListDto> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _userService.GetAllUsers();
        return Task.FromResult(_mapper.Map<UserListDto>(users));
    }
}