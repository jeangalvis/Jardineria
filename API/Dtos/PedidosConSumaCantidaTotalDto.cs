using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PedidosConSumaCantidaTotalDto
    {
        public int CodigoPedido { get; set; }
        public int SumaCantidadTotal { get; set; }
    }
}