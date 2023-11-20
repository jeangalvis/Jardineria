using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Views
{
    public class RepVentasConClientes
    {
        public string Nombre { get; set; } = null!;

        public string Apellidol { get; set; } = null!;

        public string Apellido2 { get; set; }

        public int CantidadClientes { get; set; }
    }
}