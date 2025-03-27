using Crud.Application.DTOs;

namespace Crud.Application.Services.Interfaces;

public interface IRPouyaUserService
{
    Task AddUser(RPouyaUserDTO userDTO);
    Task UpdateUser(IdRPouyaUserDTO idDTO, RPouyaUserDTO userDTO);
    Task DeleteUser(IdRPouyaUserDTO userDTO);
    Task<RPouyaUserDTO> GetUser(IdRPouyaUserDTO userDTO);
}
