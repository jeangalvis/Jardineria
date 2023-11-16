using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; }

    public ICollection<ProveedorProducto> ProveedorProductos { get; set; } = new List<ProveedorProducto>();
}
