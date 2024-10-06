using System;
using System.Collections.Generic;

namespace EcommerceModel;

public partial class Category
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
