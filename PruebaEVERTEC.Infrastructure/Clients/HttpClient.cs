
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PruebaEVERTEC.Infrastructure.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaEVERTEC.Infrastructure.Clients
{
    public class HttpClient<T> : IHttpCLient<T> where T : class
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public HttpClient(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> url)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("custom");
            _settings = url.Value;
        }

        public async Task<List<T>> GetListAsync(string url)
        {
            var response = await _httpClient.GetAsync($"{_settings.UrlString}/GetUser");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(content) ?? new List<T>();
        }
    }
}
