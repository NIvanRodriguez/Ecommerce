using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDTO
{
    public class ProductDTO
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese descripcion")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese un precio")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "Ingrese un precio oferta")]
        public decimal? PrecioOferta { get; set; }
        [Required(ErrorMessage = "Ingrese cantidad")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese un imagen")]
        public string? Imagen { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual CategoryDTO? IdCategoriaNavigation { get; set; }
    }
}
