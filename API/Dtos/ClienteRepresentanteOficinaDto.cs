using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteRepresentanteOficinaDto
    {
        public string NombreCliente { get; set; } = null!;
        public EmpleadoNombresOficinaDto CodigoEmpleadoRepVentasNavigation { get; set; }
    }
}