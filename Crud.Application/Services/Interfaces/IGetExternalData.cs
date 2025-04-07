using Crud.Application.DTOs.ExternalDataDTOs;
using Crud.Domain.DTOs;

namespace Crud.Application.Services.Interfaces;

public interface IGetExternalData
{
    Task<List<ExternalUserDTO>> GetExternalUsersService(PaginationRequest request);
}
