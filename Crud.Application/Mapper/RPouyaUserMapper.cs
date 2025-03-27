using Crud.Application.DTOs;
using Crud.Domain.Entities;

namespace Crud.Application.Mapper;

public static class RPouyaUserMapper
{
    public static RPouyaUser MapToUser(RPouyaUserDTO userDTO)
    {
        var user = new RPouyaUser()
        {
            FullName = userDTO.FullName,
            IdNumber = userDTO.IdNumber,
            UserName = userDTO.UserName,
            Password = userDTO.Password
        };
        return user;
    }

    public static RPouyaUserDTO MapToDTO(RPouyaUser user)
    {
        var userDTO = new RPouyaUserDTO()
        {
            FullName = user.FullName,
            IdNumber = user.IdNumber,
            UserName = user.UserName,
            Password = user.Password
        };
        return userDTO;
    }

    public static 
}

