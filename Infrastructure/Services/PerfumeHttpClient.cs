using Application.Contracts;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Infrastructure.Services
{
    public class PerfumeHttpClient : IPerfumeHttpClient
    {
        private readonly HttpClient _httpClient;

        public PerfumeHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            var uri = new Uri(configuration.GetSection("ApiUrls:PerfumeApiBaseUrl").Value);
            _httpClient.BaseAddress = uri;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<PerfumeDto?> GetPerfumeAsync(int id)
        {
            var perfumeDto = await _httpClient.GetFromJsonAsync<PerfumeDto>($"api/Perfume/{id}");
            return perfumeDto;
        }
    }
}
