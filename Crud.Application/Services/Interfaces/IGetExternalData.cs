using Crud.Application.DTOs.ExternalDataDTOs;
using Crud.Domain.DTOs;

namespace Crud.Application.Services.Interfaces;

public interface IGetExternalData
{
    Task<PaginationResponse<List<ExternalUserDTO>>> GetExternalUsersService(PaginationRequest request);
}
