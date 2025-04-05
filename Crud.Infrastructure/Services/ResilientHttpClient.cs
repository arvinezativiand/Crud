using Crud.Application.Services.Interfaces;
using Polly;

namespace Crud.Infrastructure.Services;

public class ResilientHttpClient : IResilientHttpClient
{
    //private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;
    //private readonly HttpClient _httpClient;

    //public ResilientHttpClient(HttpClient httpClient)
    //{
    //    _httpClient = httpClient;

    //    _retryPolicy = Policy<HttpResponseMessage>
    //        .Handle<HttpRequestException>()
    //        .OrResult(r => !r.IsSuccessStatusCode)
    //        .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(attempt));
    //}

    //public async Task<T> GetWithPolicyAsync<T>()
    //{
    //    var response = await _retryPolicy.ExecuteAsync(() => _httpClient.);
    //    return await response.Content.ReadAsAsync<T>();
    //}
}
