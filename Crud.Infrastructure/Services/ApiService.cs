using Crud.Domain.DTOs;
using Crud.Domain.Entities.ExternalUser;
using Crud.Domain.Services;
using System.Net.Http.Json;

namespace Crud.Infrastructure.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<GeneralResponse<FullExternalUserResponse>> GetData(string url, string token)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        var users = await response.Content.ReadFromJsonAsync<FullExternalUserResponse>();

        if (!response.IsSuccessStatusCode || users == null)
        {
            return new GeneralResponse<FullExternalUserResponse>
            {
                StatusCode = (int)response.StatusCode,
                Message = "Data does not recived.",
                Data = null
            };
        }

        return new GeneralResponse<FullExternalUserResponse>
        {
            StatusCode = (int)response.StatusCode,
            Message = "Data recived.",
            Data = users
        };
        
    }
}
