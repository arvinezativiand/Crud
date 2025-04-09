using Crud.Domain.DTOs;
using Crud.Domain.Entities.ExternalUser;

namespace Crud.Domain.Services;

public interface IApiService
{
    Task<GeneralResponse<FullExternalUserResponse>> GetData(string url, string token);
}
