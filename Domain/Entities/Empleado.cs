using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Empleado
{
    public int CodigoEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidol { get; set; } = null!;

    public string Apellido2 { get; set; }

    public string Extension { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CodigoOficina { get; set; } = null!;

    public int? CodigoJefe { get; set; }

    public string Puesto { get; set; }

    public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public Empleado CodigoJefeNavigation { get; set; }

    public Oficina CodigoOficinaNavigation { get; set; } = null!;

    public ICollection<Empleado> InverseCodigoJefeNavigation { get; set; } = new List<Empleado>();
}
