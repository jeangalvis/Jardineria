using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PedidoRepository : GenericRepository<Pedido>, IPedido
{
    private readonly JardineriaContext _context;
    public PedidoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Pedido> GetByIdAsync(int id)
    {
        return await _context.Pedidos

                            .FirstOrDefaultAsync(p => p.CodigoPedido == id);
    }

    public override async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _context.Pedidos
        .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Pedido> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Pedidos
         as IQueryable<Pedido>;
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
    public async Task<IEnumerable<Pedido>> GetDistintosEstados()
    {
        return await _context.Pedidos.GroupBy(p => p.Estado).Select(p => new Pedido { Estado = p.Key }).ToListAsync();
    }
    public async Task<IEnumerable<Pedido>> GetNoEntregadosATiempo()
    {
        return await _context.Pedidos
                                    .Where(p => p.FechaEsperada < p.FechaEntrega)
                                    .Select(p => new Pedido
                                    {
                                        CodigoPedido = p.CodigoPedido,
                                        CodigoCliente = p.CodigoCliente,
                                        FechaEsperada = p.FechaEsperada,
                                        FechaEntrega = p.FechaEntrega
                                    })
                                    .ToListAsync();
    }

    public async Task<IEnumerable<Pedido>> GetNoEntregadosATiempov2()
    {
        return await _context.Pedidos
                                    .Where(p => EF.Functions.DateDiffDay(p.FechaEntrega, p.FechaEsperada) >= 2)
                                    .Select(p => new Pedido
                                    {
                                        CodigoPedido = p.CodigoPedido,
                                        CodigoCliente = p.CodigoCliente,
                                        FechaEsperada = p.FechaEsperada,
                                        FechaEntrega = p.FechaEntrega
                                    })
                                    .ToListAsync();
    }
}