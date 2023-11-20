using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoOficinaDto
    {
        public string Nombre { get; set; } = null!;

        public string Apellidol { get; set; } = null!;

        public string Apellido2 { get; set; }
        public OficinaDto CodigoOficinaNavigation { get; set; } = null!;
    }
}