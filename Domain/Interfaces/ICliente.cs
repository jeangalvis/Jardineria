using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICliente : IGeneric<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClientesEspañoles();
        Task<IEnumerable<Cliente>> GetCodigoPago2008();
        Task<IEnumerable<Cliente>> GetClientesMadridRep11o30();
    }
}