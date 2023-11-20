using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class OficinaRepository : GenericRepository<Oficina>, IOficina
{
    private readonly JardineriaContext _context;
    public OficinaRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Oficina> GetByIdAsync(string id)
    {
        return await _context.Oficinas
                            .FirstOrDefaultAsync(p => p.CodigoOficina == id);
    }

    public override async Task<IEnumerable<Oficina>> GetAllAsync()
    {
        return await _context.Oficinas.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Oficina> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Oficinas as IQueryable<Oficina>;
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
    public async Task<IEnumerable<Oficina>> GetOficinasNoTrabajanRepresentantes()
    {
        return await _context.Oficinas
                            .Where(o => !o.Empleados.Any(e => e.Clientes.Any(c => c.Pedidos.Any(p => p.DetallePedidos.Any(dp => dp.CodigoProductoNavigation.GamaNavigation.Gama == "Frutales")))))
                            .ToListAsync();
    }
}