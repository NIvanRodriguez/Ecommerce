using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDTO
{
   public class CategoryDTO
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string? Nombre { get; set; }
    }
}
