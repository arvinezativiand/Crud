using Crud.Application.DbTransaction;
using Crud.Application.DTOs;
using Crud.Application.Mapper;
using Crud.Application.Services.Interfaces;
using Crud.Domain.Entities;
using Crud.Domain.Repository;

namespace Crud.Application.Services.Implimentations;

public class RPouyaFileService : IRPouyaFileService
{
    private readonly IBaseRepository<RPouyaFile> _repository;
    private readonly IRPouyaDb _rPouyaDb;

    public RPouyaFileService(IBaseRepository<RPouyaFile> repository, IRPouyaDb rPouyaDb)
    {
        _repository = repository;
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

    public async Task<List<RPouyaFileDTO>> GetAllFiles()
    {
        var result = await _rPouyaDb.Transaction(async () =>
        {
            var action = await _repository.GetAllAsync();
            return action;
        });

        var fileDTOs = RPouyaFileMapper.MapToDTOs(result);
        return fileDTOs;
    }
}
