using EcommerceDTO;
using EcommerceWebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace EcommerceWebAssembly.Services.Implementation
{
    public class DashboardServices : IDashboardServices
    {
        private readonly HttpClient _httpClient;
        public DashboardServices(HttpClient httpClient)
        {
            _httpClient =  httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>($"Dashboard/Resumen");
        }
    }
}
