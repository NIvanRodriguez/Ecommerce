using EcommerceDTO;

namespace EcommerceWebAssembly.Services.Contract
{
    public interface IUserServices
    {
        Task<ResponseDTO<List<UserDTO>>> List(string rol, string buscar);
        Task<ResponseDTO<UserDTO>> Obtener(int id);
        Task<ResponseDTO<SessionDTO>> Autorizacion(LoginDTO model);
        Task<ResponseDTO<UserDTO>> Crear(UserDTO model);
        Task<ResponseDTO<bool>> Editar(UserDTO model);
        Task<ResponseDTO<bool>> Eliminar(int id);
        
    }
}
