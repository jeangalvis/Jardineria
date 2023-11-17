using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Producto
{
    public string CodigoProducto { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Dimensiones { get; set; } = null!;

    public int Proveedor { get; set; }

    public string Descripcion { get; set; } = null!;

    public short CantidadStock { get; set; }

    public decimal PrecioActual { get; set; }

    public int IdGama { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual GamaProducto IdGamaNavigation { get; set; } = null!;

    public virtual ICollection<ProveedorProducto> ProveedorProductos { get; set; } = new List<ProveedorProducto>();
}
