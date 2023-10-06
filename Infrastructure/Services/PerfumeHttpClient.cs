using Application.Contracts;
using Application.Interfaces;
using Infrastructure.Helpers;
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
            var uri = new Uri(configuration.GetSection("ApiUrls:PerfumeApiBaseUrl").Value!);
            _httpClient.BaseAddress = uri;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<PerfumeDto?> GetPerfumeAsync(int id)
        {
            var perfumeDto = await _httpClient.GetFromJsonAsync<PerfumeDto>($"{HttpClientConstants.Controllers.Perfumes}{id}");
            return perfumeDto;
        }
        public async Task<List<PerfumeDto>?> GetPerfumesAsync(int[] ids)
        {
            var response = await _httpClient.PostAsJsonAsync($"{HttpClientConstants.Controllers.Perfumes}{HttpClientConstants.PerfumeRelatives.PerfumesList}", ids);

            var perfumes = await response.Content.ReadFromJsonAsync<List<PerfumeDto>>();
                
            return perfumes;
        }
    }
}
