using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClientePagosDto
    {
        public string NombreCliente { get; set; } = null!;
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public DateOnly? PrimerPago { get; set; }
        public DateOnly? UltimoPago { get; set; }
    }
}