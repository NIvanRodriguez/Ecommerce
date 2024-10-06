using System;
using System.Collections.Generic;

namespace EcommerceModel;

public partial class DetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public int? Idventa { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Venta? IdventaNavigation { get; set; }
}
