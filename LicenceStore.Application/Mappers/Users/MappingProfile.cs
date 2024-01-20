﻿using AutoMapper;
using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Domain.Entities;

namespace LicenceStore.Application.Mappers.Users;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpdateUserDto, ApplicationUser>().ReverseMap();
        CreateMap<ApplicationUser, UserDetailsDto>().ConstructUsing(x => GetUserDetails(x));
        CreateMap<IEnumerable<ApplicationUser>, UserListDto>().ConstructUsing(x => GetUserList(x));
    }

    private static UserDetailsDto GetUserDetails(ApplicationUser user)
    {
        return new UserDetailsDto
        (
            user.FirstName,
            user.LastName,
            user.Email,
            user.NormalizedEmail,
            user.UserName,
            user.NormalizedUserName,
            user.Licences.Select(l => l.Name),
            user.Roles
        );
    }

    private static UserListDto GetUserList(IEnumerable<ApplicationUser> users)
    {
        var userList = users.Select(GetUserDetails).ToList();
        return new UserListDto(userList);
    }
}