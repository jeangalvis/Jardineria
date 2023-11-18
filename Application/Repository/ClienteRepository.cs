using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly JardineriaContext _context;
    public ClienteRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
                            .FirstOrDefaultAsync(p => p.CodigoCliente == id);
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Clientes as IQueryable<Cliente>;
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

    public async Task<IEnumerable<Cliente>> GetClientesEspañoles()
    {
        return await _context.Clientes
                                    .Where(p => p.Pais.ToLower() == "Spain".ToLower()).ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetCodigoPago2008()
    {
        return await _context.Clientes
                                    .Include(p => p.Pagos)
                                    .Where(p => p.Pagos.Any(p => p.FechaPago.Year == 2008))
                                    .GroupBy(p => p.CodigoCliente)
                                    .Select(p => new Cliente { CodigoCliente = p.Key })
                                    .ToListAsync();
    }
}