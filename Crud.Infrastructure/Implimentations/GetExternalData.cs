using Crud.Application.DTOs.ExternalDataDTOs;
using Crud.Application.Mapper.ExternalDataDTO;
using Crud.Application.Services.Interfaces;
using Crud.Domain.DTOs;
using Crud.Domain.Entities.ExternalUser;
using Crud.Domain.Services;
using Crud.Infrastructure.Implimentations;
using Microsoft.Extensions.Configuration;

namespace Crud.Application.Services.Implimentation;

public class GetExternalData : Pagination<ExternalUsers>, IGetExternalData
{
    private readonly IApiService _apiService;
    private readonly string token;
    private readonly string url;
    private readonly string order_by;
    private readonly string order_direction;
    private readonly string per_page;

    public GetExternalData(IConfiguration configuration, IApiService apiService)
    {
        _apiService = apiService;
        token = configuration["ExternalApi:TokenString"] ?? "";
        url = configuration["ExternalApi:UrlString"] ?? "";
        order_by = configuration["ExternalApi:DefaultOrderBy"] ?? "Id";
        order_direction = configuration["ExternalApi:DefaultOrderDirection"] ?? "asc";
    }

    public async Task<PaginationResponse<List<ExternalUserDTO>>> GetExternalUsersService(PaginationRequest request)
    {
        var queryString = new Dictionary<string, string>
        {
            ["order_by"] = order_by,
            ["order_direction"] = order_direction,
            ["per_page"] = request.length.ToString(),
            ["page"] = GetPageNumber(request).ToString(),
        };

        var uri = new UriBuilder(url)
        {
            Query = string.Join("&", queryString.Select(kvp => $"{kvp.Key}={kvp.Value}"))
        };

        var result = await _apiService.GetData(uri.ToString(), token);
        if (result.Data.Data == null)
        {
            return null;
        }
        //var userPaging = Paging(result.Data, request);
        var usersDto = ExternalDataMapper.MapToDTO(result.Data.Data);

        return new PaginationResponse<List<ExternalUserDTO>>
        {
            RecordsTotal = result.Data.Meta.Total,
            RecordsFiltered = result.Data.Meta.Total,
            Data = usersDto
        };
    }
}
