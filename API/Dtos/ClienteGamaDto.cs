using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ClienteGamaDto
    {
        public string NombreCliente { get; set; } = null!;
        public List<GamaProducto> GamasCompradas { get; set; } = null!;
    }
}