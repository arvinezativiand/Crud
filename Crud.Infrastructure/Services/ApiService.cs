using Crud.Domain.DTOs;
using Crud.Domain.Entities;
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

    public async Task<GeneralResponse<IEnumerable<ExternalUsers>>> GetData(string url, string header)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("token", header);


        var response = await _httpClient.SendAsync(request);
        var users = await response.Content.ReadFromJsonAsync<IEnumerable<ExternalUsers>>();

        if (!response.IsSuccessStatusCode || users == null)
        {
            return new GeneralResponse<IEnumerable<ExternalUsers>>
            {
                StatusCode = (int)response.StatusCode,
                Message = "Data did not recived. Try again later",
                Data = null
            };
        }

        return new GeneralResponse<IEnumerable<ExternalUsers>>
        {
            StatusCode = 200,
            Message = "Data recived.",
            Data = users
        };
        
    }
}
