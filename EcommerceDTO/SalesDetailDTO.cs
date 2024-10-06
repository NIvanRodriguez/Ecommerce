using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDTO
{
    public class SalesDetailDTO
    {
        public int IdDetalleVenta { get; set; }

        public int? Idventa { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Total { get; set; }

    }
}
