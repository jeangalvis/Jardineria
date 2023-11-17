using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ProveedorProductoRepository : GenericRepository<ProveedorProducto>, IProveedorProducto
{
    private readonly JardineriaContext _context;
    public ProveedorProductoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ProveedorProducto> GetByIdAsync(int id)
    {
        return await _context.ProveedorProductos
                            .FirstOrDefaultAsync(p => p.IdProvprod == id);
    }

    public override async Task<IEnumerable<ProveedorProducto>> GetAllAsync()
    {
        return await _context.ProveedorProductos.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<ProveedorProducto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.ProveedorProductos as IQueryable<ProveedorProducto>;
        if (!string.IsNullOrEmpty(search))
        {
            // query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
}