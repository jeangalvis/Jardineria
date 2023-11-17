using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DetallePedido
{
    public int? Cantidad { get; set; }

    public decimal? PrecioUnidad { get; set; }

    public short? NumeroLinea { get; set; }

    public int CodigoPedido { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string IdDetallePedido { get; set; } = null!;

    public Pedido CodigoPedidoNavigation { get; set; } = null!;

    public Producto CodigoProductoNavigation { get; set; } = null!;
}
