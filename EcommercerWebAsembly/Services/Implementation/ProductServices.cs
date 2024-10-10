using EcommerceDTO;
using EcommerceWebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace EcommerceWebAssembly.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly HttpClient _httpClient;
        public ProductServices(HttpClient httpClient)
        {
         _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ProductDTO>>> Catalogo(string categoria, string buscar)
        {

            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Producto/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<ProductDTO>> Crear(ProductDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto/Crear", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Editar(ProductDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Producto/Editar", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<ProductDTO>>> List(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Producto/Lista/{buscar}");
        }

        public async Task<ResponseDTO<ProductDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductDTO>>($"Producto/Obtener/{id}");
        }
    }
}
