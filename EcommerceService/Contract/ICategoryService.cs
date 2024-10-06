using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceDTO;
namespace EcommerceService.Contract
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> Lista( string buscar);
        Task<List<CategoryDTO>> Obtener(int id);
       
        Task<List<CategoryDTO>> Crear(CategoryDTO model);
        Task<bool> Editar(CategoryDTO model);
        Task<bool> Eliminar(int id);
    }
}
