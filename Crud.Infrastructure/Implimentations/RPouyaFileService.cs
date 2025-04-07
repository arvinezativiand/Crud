using Crud.Application.DbTransaction;
using Crud.Application.DTOs;
using Crud.Application.Mapper;
using Crud.Application.Services.Interfaces;
using Crud.Domain.DTOs;
using Crud.Domain.Entities;
using Crud.Domain.Repository;
using Crud.Infrastructure.EFCore;
using Crud.Infrastructure.Repository;

namespace Crud.Application.Services.Implimentations;

public class RPouyaFileService : BaseRepository<RPouyaFile>, IRPouyaFileService
{
    private readonly IBaseRepository<RPouyaFile> _repository;
    private readonly IRPouyaDb _rPouyaDb;

    public RPouyaFileService(IRPouyaDb rPouyaDb, RPouyaDbContext dbContext) : base(dbContext)
    {
        _rPouyaDb = rPouyaDb;
    }

    public async Task AddFile(RPouyaFileDTO fileDTO)
    {
        var file = RPouyaFileMapper.MapToFile(fileDTO);
        var result = await _rPouyaDb.Transaction(async () =>
        {
            var action = await _repository.AddAsync(file);
            return action;
        });
    }

    public async Task<PaginationResponse<List<RPouyaFileDTO>>> GetAllFiles(PaginationRequest request)
    {
        var result = await _rPouyaDb.Transaction(async () =>
        {
            var action = await _repository.GetAllAsync(request.start, request.length);
            return action;
        });

        var fileDTOs = RPouyaFileMapper.MapToDTOs(result.Data);

        return new PaginationResponse<List<RPouyaFileDTO>>
        {
            RecordsFiltered = result.RecordsFiltered,
            RecordsTotal = result.RecordsTotal,
            Data = fileDTOs
        };
    }
}
