using Crud.Application.DTOs;

namespace Crud.Application.Services.Interfaces;

public interface IRPouyaFileService
{
    Task AddFile(RPouyaFileDTO fileDTO);
    Task<List<RPouyaFileDTO>> GetAllFiles();
}
