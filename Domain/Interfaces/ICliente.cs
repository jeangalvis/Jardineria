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
        Task<Cliente> GetClienteMayorLimiteCredito();
        Task<IEnumerable<Cliente>> GetClienteCreditoMayorPagoRealizado();
        Task<Cliente> GetClienteMayorLimiteCreditoV2();
        Task<IEnumerable<Cliente>> GetClientesNoHanPagadoV2();
        Task<IEnumerable<Cliente>> GetClientesSiHanPagado();
        Task<IEnumerable<Cliente>> GetClientesNoHanPagadoV3();
        Task<IEnumerable<Cliente>> GetClientesSiHanPagadoV2();
        Task<IEnumerable<ClientesxPedido>> GetClientesxPedido();
        Task<IEnumerable<Cliente>> GetClientesPedidos2008();
        Task<IEnumerable<ClienteRepOficinaPago>> GetClienteRepOficinaPagos();
        Task<IEnumerable<ClienteRepCiudadOficina>> GetClienteRepCiudadOficinas();
        Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetClientesEspañoles(int pageIndex, int pageSize, string search);
        Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetClientesMadridRep11o30(int pageIndex, int pageSize, string search);
        Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetClientePedidoEntregadoTarde(int pageIndex, int pageSize, string search);
        Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetClientesPedidos2008(int pageIndex, int pageSize, string search);
    }
}