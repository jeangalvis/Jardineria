using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pago
{
    public int CodigoPago { get; set; }

    public string FormaPago { get; set; }

    public int? IdTransaccion { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal? Total { get; set; }

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
