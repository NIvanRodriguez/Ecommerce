using EcommerceDTO;
using EcommerceWebAssembly.Services.Contract;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;

namespace EcommerceWebAssembly.Services.Implementation
{
    public class UserServices:IUserServices
    {
        private readonly HttpClient _httpClient;
        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SessionDTO>> Autorizacion(LoginDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SessionDTO>>();
            return result;
        }


        public async Task<ResponseDTO<UserDTO>> Crear(UserDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UserDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Editar(UserDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
          return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");
            
        }

        public async Task<ResponseDTO<List<UserDTO>>> List(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UserDTO>>>($"Usuario/Lista/{rol}/{buscar}");
        }

        public async Task<ResponseDTO<UserDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UserDTO>>($"Usuario/Obtener/{id}");
        }
    }

}
