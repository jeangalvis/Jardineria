using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Views
{
    public class PedidosConCantidadProductos
    {
        public int CodigoPedido { get; set; }
        public int ProductosDiferentes { get; set; }
    }
}