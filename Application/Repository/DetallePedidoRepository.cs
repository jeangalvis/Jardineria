using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedido
{
    private readonly JardineriaContext _context;
    public DetallePedidoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<DetallePedido> GetByIdAsync(string id)
    {
        return await _context.DetallePedidos
                            .FirstOrDefaultAsync(p => p.IdDetallePedido == id);
    }

    public override async Task<IEnumerable<DetallePedido>> GetAllAsync()
    {
        return await _context.DetallePedidos.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<DetallePedido> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.DetallePedidos as IQueryable<DetallePedido>;
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