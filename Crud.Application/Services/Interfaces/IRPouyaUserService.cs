using Crud.Application.DTOs;
using Crud.Domain.DTOs;
using Crud.Domain.Entities;
using Crud.Domain.Repository;

namespace Crud.Application.Services.Interfaces;

public interface IRPouyaUserService: IBaseRepository<RPouyaUser>
{
    Task AddUser(RPouyaUserDTO userDTO);
    Task UpdateUser(IdRPouyaUserDTO idDTO, RPouyaUserDTO userDTO);
    Task DeleteUser(IdRPouyaUserDTO userDTO);
    Task<PaginationResponse<List<RPouyaUserDTO>>> GetAllUsers(PaginationRequest request);
    Task<RPouyaUserDTO> GetUser(IdRPouyaUserDTO userDTO);
}
