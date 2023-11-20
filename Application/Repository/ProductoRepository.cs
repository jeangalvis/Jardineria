using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly JardineriaContext _context;
    public ProductoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Producto> GetByIdAsync(string id)
    {
        return await _context.Productos
                            .FirstOrDefaultAsync(p => p.CodigoProducto == id);
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Producto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Productos as IQueryable<Producto>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
    public async Task<IEnumerable<Producto>> GetOrnamentalesStock100()
    {
        return await _context.Productos
                                    .Where(p => p.Gama.ToLower() == "Ornamentales".ToLower() && p.CantidadEnStock > 100)
                                    .OrderByDescending(p => p.PrecioVenta)
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Producto>> GetProductosSinPedido()
    {
        return await _context.Productos
                                    .Where(p => !p.DetallePedidos.Any())
                                    .ToListAsync();
    }

    public async Task<IEnumerable<Producto>> GetProductosGamaSinPedido()
    {
        return await _context.Productos
                                    .Include(p => p.GamaNavigation)
                                    .Where(p => !p.DetallePedidos.Any())
                                    .Select(p => new Producto
                                    {
                                        Nombre = p.Nombre,
                                        GamaNavigation = new GamaProducto
                                        {
                                            Gama = p.GamaNavigation.Gama,
                                            DescripcionHtml = p.GamaNavigation.DescripcionHtml,
                                            DescripcionTexto = p.GamaNavigation.DescripcionTexto,
                                            Imagen = p.GamaNavigation.Imagen
                                        }
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidos()
    {
        return await _context.Productos
                                    .Select(p => new ProductosMasVendidos
                                    {
                                        Nombre = p.Nombre,
                                        Cantidad = p.DetallePedidos.Sum(p => p.Cantidad)
                                    })
                                    .OrderByDescending(p => p.Cantidad)
                                    .Take(20)
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidosAgrupadosCodigo()
    {
        return await _context.DetallePedidos
                                    .GroupBy(p => p.CodigoProducto)
                                    .Select(p => new ProductosMasVendidos
                                    {
                                        Nombre = p.First().CodigoProductoNavigation.Nombre,
                                        Cantidad = p.Sum(p => p.Cantidad)
                                    })
                                    .OrderByDescending(p => p.Cantidad)
                                    .Take(20)
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidosAgrupadosCodigoFiltradoOr()
    {
        return await _context.DetallePedidos
                            .GroupBy(p => p.CodigoProducto.StartsWith("Or"))
                            .Select(p => new ProductosMasVendidos
                            {
                                Nombre = p.First().CodigoProductoNavigation.Nombre,
                                Cantidad = p.Sum(p => p.Cantidad)
                            })
                            .OrderByDescending(p => p.Cantidad)
                            .Take(20)
                            .ToListAsync();
    }
    public async Task<IEnumerable<TotalFacturadoProductos>> GetProductosVentasMas3000()
    {
        return await _context.DetallePedidos
                                    .Where(p => p.PrecioUnidad * p.Cantidad > 3000)
                                    .Select(p => new TotalFacturadoProductos
                                    {
                                        Nombre = p.CodigoProductoNavigation.Nombre,
                                        UnidadesVendidas = p.Cantidad,
                                        TotalFacturado = p.Cantidad * p.PrecioUnidad,
                                        TotalFacturadoImpuestos = p.Cantidad * p.PrecioUnidad * 1.21m
                                    })
                                    .ToListAsync();

    }
}