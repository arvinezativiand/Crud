using Crud.Application.DTOs;
using Crud.Domain.DTOs;

namespace Crud.Application.Services.Interfaces;

public interface IRPouyaFileService
{
    Task AddFile(RPouyaFileDTO fileDTO);
    Task<PaginationResponse<List<RPouyaFileDTO>>> GetAllFiles(PaginationRequest request);
}
