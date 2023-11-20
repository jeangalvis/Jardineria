using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IPedido : IGeneric<Pedido>
    {
        Task<IEnumerable<Pedido>> GetDistintosEstados();
        Task<IEnumerable<Pedido>> GetNoEntregadosATiempo();
        Task<IEnumerable<Pedido>> GetNoEntregadosATiempov2();
        Task<IEnumerable<Pedido>> GetPedidosRechazados();
        Task<IEnumerable<Pedido>> GetPedidosEntregadosEnero();
        Task<IEnumerable<PedidoPorEstado>> GetPedidoPorEstados();
        Task<IEnumerable<PedidosConCantidadProductos>> GetPedidoConCantidadProductos();
        Task<IEnumerable<PedidosConSumaCantidadTotal>> GetPedidosConSumaCantidadTotal();
    }
}