using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PedidoDto
    {
        public int CodigoPedido { get; set; }

        public DateTime? FechaPedido { get; set; }

        public DateTime? FechaEsperada { get; set; }

        public string FechaEntrega { get; set; }

        public string Estado { get; set; }

        public string Comentarios { get; set; }

        public int CodigoEmpleado { get; set; }

        public int CodigoCliente { get; set; }

        public int CodigoPago { get; set; }
    }
}