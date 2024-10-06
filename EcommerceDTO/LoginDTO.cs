using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDTO
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "Ingrese correo")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        public string? Clave { get; set; }
        public string? Rol { get; set; }
    }
}
