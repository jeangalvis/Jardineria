using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteNombreDto
    {
        public string NombreCliente { get; set; } = null!;

        public string NombreContacto { get; set; }

        public string ApellidoContacto { get; set; }
    }
}