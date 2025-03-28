using Crud.Application.DTOs;
using Crud.Domain.Entities;
using System.Linq;

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

    public static List<RPouyaUserDTO> MapToDTOs(IEnumerable<RPouyaUser> users)
    {
        List<RPouyaUserDTO> userDTOs = [];
        foreach (var user in users)
        {
            var userDTO = MapToDTO(user);
            userDTOs.Add(userDTO);
        }

        return userDTOs;
    }

    public static List<RPouyaUser> MapToUsers(IEnumerable<RPouyaUserDTO> userDTOs)
    {
        List<RPouyaUser> users = [];

        foreach (var userDTO in userDTOs)
        {
            var user = MapToUser(userDTO);
            users.Append(user);
        }

        return users;
    }
}

