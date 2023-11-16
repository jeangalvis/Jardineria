using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pedido
{
    public int CodigoPedido { get; set; }

    public DateTime? FechaPedido { get; set; }

    public DateTime? FechaEsperada { get; set; }

    public string FechaEntrega { get; set; }

    public string Estado { get; set; }

    public string Comentarios { get; set; }

    public int CodigoEmpleado { get; set; }

    public int CodigoCliente { get; set; }

    public int CodigoPago { get; set; }

    public Cliente CodigoClienteNavigation { get; set; } = null!;

    public Empleado CodigoEmpleadoNavigation { get; set; } = null!;

    public Pago CodigoPagoNavigation { get; set; } = null!;

    public ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}
