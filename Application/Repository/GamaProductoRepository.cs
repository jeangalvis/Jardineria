using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class GamaProductoRepository : GenericRepository<GamaProducto>, IGamaProducto
{
    private readonly JardineriaContext _context;
    public GamaProductoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<GamaProducto> GetByIdAsync(string id)
    {
        return await _context.GamaProductos
                            .FirstOrDefaultAsync(p => p.Gama == id);
    }

    public override async Task<IEnumerable<GamaProducto>> GetAllAsync()
    {
        return await _context.GamaProductos.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<GamaProducto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.GamaProductos as IQueryable<GamaProducto>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.DescripcionTexto.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
}