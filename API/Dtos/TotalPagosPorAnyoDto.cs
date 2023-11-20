using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TotalPagosPorAnyoDto
    {
        public int Anyo { get; set; }
        public decimal TotalPagos { get; set; }
    }
}