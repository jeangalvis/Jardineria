using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PagoRepository : GenericRepository<Pago>, IPago
{
    private readonly JardineriaContext _context;
    public PagoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Pago> GetByIdAsync(string id)
    {
        return await _context.Pagos
                            .FirstOrDefaultAsync(p => p.IdTransaccion == id);
    }

    public override async Task<IEnumerable<Pago>> GetAllAsync()
    {
        return await _context.Pagos.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Pago> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Pagos as IQueryable<Pago>;
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
    public async Task<IEnumerable<Pago>> GetPagos2008Paypal()
    {
        return await _context.Pagos
                                .Where(p => p.FechaPago.Year == 2008 && p.FormaPago.ToLower() == "PayPal".ToLower())
                                .OrderByDescending(p => p.CodigoCliente)
                                .ToListAsync();
    }
    public async Task<IEnumerable<Pago>> GetFormasPago()
    {
        return await _context.Pagos
                                .GroupBy(p => p.FormaPago)
                                .Select(p => new Pago
                                {
                                    FormaPago = p.Key
                                })
                                .ToListAsync();
    }
}