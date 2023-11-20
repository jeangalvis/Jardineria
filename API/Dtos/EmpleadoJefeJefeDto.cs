using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoJefeJefeDto
    {
        public string Nombre { get; set; } = null!;
        public EmpleadoJefeJefeDto CodigoJefeNavigation { get; set; }
    }
}