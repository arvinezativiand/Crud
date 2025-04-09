using Crud.Application.DbTransaction;
using Crud.Application.DTOs;
using Crud.Application.Mapper;
using Crud.Application.Services.Interfaces;
using Crud.Domain.DTOs;
using Crud.Domain.Entities;
using Crud.Infrastructure.EFCore;
using Crud.Infrastructure.Repository;

namespace Crud.Application.Services.Implimentations;

public class RPouyaUserService : BaseRepository<RPouyaUser>, IRPouyaUserService
{
    private readonly IRPouyaDb _rPouyaDb;

    public RPouyaUserService( IRPouyaDb rPouyaDb, RPouyaDbContext dbContext) : base(dbContext)
    {
        _rPouyaDb = rPouyaDb;

    }

    public async Task AddUser(RPouyaUserDTO userDTO)
    {
        var user = RPouyaUserMapper.MapToUser(userDTO);

        var result = await _rPouyaDb.Transaction<RPouyaUser>(async () =>
        {
            var action = await AddAsync(user);
            return action;
        });
    }

    public async Task DeleteUser(IdRPouyaUserDTO userDTO)
    {
        var result = await _rPouyaDb.Transaction(async () =>
        {
            var action = await DeleteAsync(userDTO.Id);
            return action;
        });
    }

    public async Task<PaginationResponse<List<RPouyaUserDTO>>> GetAllUsers(PaginationRequest request)
    {
        var result = await _rPouyaDb.Transaction(async () =>
        {
            var action = await GetAllAsync(request.start, request.length);
            return action;
        });

        List<RPouyaUserDTO> users = RPouyaUserMapper.MapToDTOs(result.Data);

        return new PaginationResponse<List<RPouyaUserDTO>>
        {
            RecordsFiltered = result.RecordsFiltered,
            RecordsTotal = result.RecordsTotal,
            Data = users
        };
    }

    public async Task<RPouyaUserDTO> GetUser(IdRPouyaUserDTO userDTO)
    {
        var result = await _rPouyaDb.Transaction(async () =>
        {
            var action = await GetByIdAsync(userDTO.Id);
            return action;
        });
        var user = RPouyaUserMapper.MapToDTO(result);

        return user;
    }

    public async Task UpdateUser(IdRPouyaUserDTO idDTO, RPouyaUserDTO userDTO)
    {
        var getUser = await GetUser(idDTO);
        var user = RPouyaUserMapper.MapToUser(userDTO);
        var result = _rPouyaDb.Transaction(async () =>
        {
            user.UserName = userDTO.UserName;
            user.IdNumber = userDTO.IdNumber;
            user.FullName = userDTO.FullName;
            user.Password = userDTO.Password;

            var action = await UpdateAsync(user);
            return action;
        });
    }
}
