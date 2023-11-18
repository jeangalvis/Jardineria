using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICliente : IGeneric<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClientesEspañoles();
    }
}