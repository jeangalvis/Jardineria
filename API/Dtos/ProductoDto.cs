using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductoDto
    {
        public string CodigoProducto { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Dimensiones { get; set; } = null!;

        public int Proveedor { get; set; }

        public string Descripcion { get; set; } = null!;

        public short CantidadStock { get; set; }

        public decimal PrecioActual { get; set; }

        public int IdGama { get; set; }
    }
}