using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IPago : IGeneric<Pago>
    {
        Task<IEnumerable<Pago>> GetPagos2008Paypal();
        Task<IEnumerable<Pago>> GetFormasPago();
        Task<decimal> GetPagoMedio();
        Task<IEnumerable<TotalPagosPorAnyo>> GetTotalPagosPorAnyos();
    }
}