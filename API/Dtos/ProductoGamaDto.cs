using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductoGamaDto
    {

        public string Nombre { get; set; } = null!;
        public GamaProductoDto GamaNavigation { get; set; } = null!;
    }
}