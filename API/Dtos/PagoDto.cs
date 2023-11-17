using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PagoDto
    {
        public int CodigoPago { get; set; }

        public string FormaPago { get; set; }

        public int? IdTransaccion { get; set; }

        public DateTime? FechaPago { get; set; }

        public decimal? Total { get; set; }
    }
}