using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IProducto : IGeneric<Producto>
    {
        Task<IEnumerable<Producto>> GetOrnamentalesStock100();
        Task<IEnumerable<Producto>> GetProductosSinPedido();
        Task<IEnumerable<Producto>> GetProductosGamaSinPedido();
        Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidos();
        Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidosAgrupadosCodigo();
        Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidosAgrupadosCodigoFiltradoOr();
        Task<IEnumerable<TotalFacturadoProductos>> GetProductosVentasMas3000();
    }
}