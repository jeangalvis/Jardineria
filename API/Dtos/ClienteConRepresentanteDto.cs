using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteConRepresentanteDto
    {
        public string NombreCliente { get; set; } = null!;
        public EmpleadoNombresDto CodigoEmpleadoRepVentasNavigation { get; set; }
    }
}