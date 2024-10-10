using EcommerceDTO;
using EcommerceWebAssembly.Services.Contract;
using System.Net.Http.Json;
using System.Reflection;

namespace EcommerceWebAssembly.Services.Implementation
{
    public class CategoryServices : ICategoryServices
    {
        private readonly HttpClient _httpClient;    
        public CategoryServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoryDTO>> Crear(CategoryDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/Crear", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoryDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoryDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Categoria/Editar", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
           return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<CategoryDTO>>> List(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoryDTO>>>($"Categoria/Lista/{buscar}");
        }

        public async Task<ResponseDTO<CategoryDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoryDTO>>($"Categoria/Obtener/{id}");
        }
    }
}
