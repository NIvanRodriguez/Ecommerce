using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDTO
{
    public class SaleDTO
    {
        public int Idventa { get; set; }

        public int? IdUsuario { get; set; }

        public decimal? Total { get; set; }

        public virtual ICollection<SalesDetailDTO> DetalleVenta { get; set; } = new List<SalesDetailDTO>();

    }
}
