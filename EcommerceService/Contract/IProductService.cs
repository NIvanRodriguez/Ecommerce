using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceDTO;

namespace EcommerceService.Contract
{
    public interface IProductService
    { 
        Task<List<ProductDTO>> Lista( string buscar);
        Task<List<ProductDTO>> Catalogo(string categoria, string buscar);
        Task<List<ProductDTO>> Obtener(int id);
        Task<List<ProductDTO>> Crear(ProductDTO model);
        Task<bool> Editar(ProductDTO model);
        Task<bool> Eliminar(int id);
    }
}
