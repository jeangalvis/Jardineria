using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Views
{
    public class ClientePagos
    {
        public string NombreCliente { get; set; } = null!;
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public DateOnly? PrimerPago { get; set; }
        public DateOnly? UltimoPago { get; set; }
    }
}