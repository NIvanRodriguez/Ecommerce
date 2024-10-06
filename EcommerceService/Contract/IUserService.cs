using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcommerceDTO;

namespace EcommerceService.Contract
{
    public interface IUserService
    {
        Task<List<UserDTO>> Lista(string rol, string buscar);
        Task<List<UserDTO>> Obtener(int id);
        Task<List<SessionDTO>> Autorizacion(LoginDTO model);
        Task<List<UserDTO>> Crear(UserDTO model);
        Task<bool> Editar(UserDTO model);
        Task<bool> Eliminar(int id);

    }
}
