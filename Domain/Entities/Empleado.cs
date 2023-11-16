using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Empleado
{
    public int CodigoEmpleado { get; set; }

    public string Nombre { get; set; }

    public string Apellido1 { get; set; }

    public string Apellido2 { get; set; }

    public string Extension { get; set; }

    public string Email { get; set; }

    public int? CodigoJefe { get; set; }

    public string Puesto { get; set; }

    public string CodigoOficina { get; set; } = null!;

    public Empleado CodigoJefeNavigation { get; set; }

    public Oficina CodigoOficinaNavigation { get; set; } = null!;

    public ICollection<Empleado> InverseCodigoJefeNavigation { get; set; } = new List<Empleado>();

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
