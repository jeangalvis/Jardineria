using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface ICliente : IGeneric<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClientesEspañoles();
        Task<IEnumerable<Cliente>> GetCodigoPago2008();
        Task<IEnumerable<Cliente>> GetClientesMadridRep11o30();
        Task<IEnumerable<Cliente>> GetClienteRepresentanteVenta();
        Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaPago();
        Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaNoPago();
        Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaPagoOficina();
        Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaNoPagoOficina();
        Task<IEnumerable<Cliente>> GetClientePedidoEntregadoTarde();
        Task<IEnumerable<ClienteGama>> GetGamaProductosxCliente();
        Task<IEnumerable<Cliente>> GetClientesNoHanPagado();
        Task<IEnumerable<Cliente>> GetClientesNoHanPagadoNiPedido();
        Task<IEnumerable<Cliente>> GetClientesHanPagadoNoPedido();
        Task<IEnumerable<ClientesPorPais>> GetClientesPorPais();
        Task<IEnumerable<ClientePorCiudad>> GetClientesPorCiudad();
        Task<IEnumerable<ClientePorCiudad>> GetClientesPorCiudadM();
        Task<TotalCliente> GetTotalClientesSinRep();
        Task<IEnumerable<ClientePagos>> GetPrimerUltimoPago();
    }
}