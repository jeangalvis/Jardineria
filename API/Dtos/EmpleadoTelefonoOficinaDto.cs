using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoTelefonoOficinaDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellidol { get; set; } = null!;
        public string Apellido2 { get; set; }
        public string Puesto { get; set; }
        public string Telefono { get; set; } = null!;
    }
}