using EcommerceDTO;
using EcommerceWebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace EcommerceWebAssembly.Services.Implementation
{
    public class SaleServices : ISaleServices
    {
        private readonly HttpClient _httpClient;
        public SaleServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
         
        public async Task<ResponseDTO<SaleDTO>> Registrar(SaleDTO model)
        {

            var response = await _httpClient.PostAsJsonAsync("Venta/Registrar", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SaleDTO>>();
            return result;
        }
    }
}
