using AutoMapper;
using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Application.Common.Exceptions;
using LicenceStore.Application.Common.Interfaces;
using MediatR;

namespace LicenceStore.Application.Users.Queries;

public record GetOneUserQuery(string UserId) : IRequest<UserDetailsDto>;

public class GetOneUserQueryHandler : IRequestHandler<GetOneUserQuery, UserDetailsDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetOneUserQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserDetailsDto> Handle(GetOneUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(request.UserId);
        if (user == null)
            throw new NotFoundException("User not found");

        return await Task.FromResult(_mapper.Map<UserDetailsDto>(user));
    }
}