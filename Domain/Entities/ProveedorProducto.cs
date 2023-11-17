using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ProveedorProducto
{
    public int IdProvprod { get; set; }

    public decimal? PrecioProveedor { get; set; }

    public int ProveedorId { get; set; }

    public string ProductoCodigoProducto { get; set; } = null!;

    public Producto ProductoCodigoProductoNavigation { get; set; } = null!;

    public Proveedor Proveedor { get; set; } = null!;
}
