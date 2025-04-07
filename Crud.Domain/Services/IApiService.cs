using Crud.Domain.DTOs;
using Crud.Domain.Entities;

namespace Crud.Domain.Services;

public interface IApiService
{
    Task<GeneralResponse<IEnumerable<ExternalUsers>>> GetData(string url, string headers);
}
