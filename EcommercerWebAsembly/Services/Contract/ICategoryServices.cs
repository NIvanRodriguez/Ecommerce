using EcommerceDTO;

namespace EcommerceWebAssembly.Services.Contract
{
    public interface ICategoryServices
    {
        Task<ResponseDTO<List<CategoryDTO>>> List(string buscar);
        Task<ResponseDTO<CategoryDTO>> Obtener(int id);
        Task<ResponseDTO<CategoryDTO>> Crear(CategoryDTO model);
        Task<ResponseDTO<bool>> Editar(CategoryDTO model);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
