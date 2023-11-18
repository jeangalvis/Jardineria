using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPedido : IGeneric<Pedido>
    {
        Task<IEnumerable<Pedido>> GetDistintosEstados();
        Task<IEnumerable<Pedido>> GetNoEntregadosATiempo();
        Task<IEnumerable<Pedido>> GetNoEntregadosATiempov2();
    }
}