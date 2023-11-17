using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProveedorProductoDto
    {
        public int IdProvprod { get; set; }

        public decimal? PrecioProveedor { get; set; }

        public int ProveedorId { get; set; }

        public string ProductoCodigoProducto { get; set; } = null!;
    }
}