using EcommerceDTO;

namespace EcommerceWebAssembly.Services.Contract
{
    public interface IProductServices
    {
        Task<ResponseDTO<List<ProductDTO>>> List( string buscar);
        Task<ResponseDTO<List<ProductDTO>>> Catalogo(string categoria, string buscar);
        Task<ResponseDTO<ProductDTO>> Obtener(int id);
        Task<ResponseDTO<ProductDTO>> Crear(ProductDTO model);
        Task<ResponseDTO<bool>> Editar(ProductDTO model);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
