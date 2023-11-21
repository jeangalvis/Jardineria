using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly JardineriaContext _context;
    public EmpleadoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Empleados
                            .FirstOrDefaultAsync(p => p.CodigoEmpleado == id);
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Empleado> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Empleados as IQueryable<Empleado>;
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
    public async Task<IEnumerable<Empleado>> GetEmpleadosJefeDelJefe()
    {
        return await _context.Empleados
                                    .Include(p => p.CodigoJefeNavigation)
                                    .ThenInclude(p => p.CodigoJefeNavigation.CodigoJefeNavigation)
                                    .Select(p => new Empleado
                                    {
                                        Nombre = p.Nombre,
                                        CodigoJefeNavigation = new Empleado
                                        {
                                            Nombre = p.CodigoJefeNavigation.Nombre,
                                            CodigoJefeNavigation = new Empleado
                                            {
                                                Nombre = p.CodigoJefeNavigation.CodigoJefeNavigation.Nombre
                                            }
                                        }
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Empleado>> GetEmpleadosSinClienteConOficina()
    {
        return await _context.Empleados
                                    .Include(p => p.Clientes)
                                    .Include(p => p.CodigoOficinaNavigation)
                                    .Where(p => !p.Clientes.Any())
                                    .Select(p => new Empleado
                                    {
                                        Nombre = p.Nombre,
                                        Apellidol = p.Apellidol,
                                        Apellido2 = p.Apellido2,
                                        CodigoOficinaNavigation = new Oficina
                                        {
                                            CodigoOficina = p.CodigoOficinaNavigation.CodigoOficina,
                                            Ciudad = p.CodigoOficinaNavigation.Ciudad,
                                            Pais = p.CodigoOficinaNavigation.Pais,
                                            Region = p.CodigoOficinaNavigation.Region,
                                            CodigoPostal = p.CodigoOficinaNavigation.CodigoPostal,
                                            Telefono = p.CodigoOficinaNavigation.Telefono,
                                            LineaDireccion1 = p.CodigoOficinaNavigation.LineaDireccion1,
                                            LineaDireccion2 = p.CodigoOficinaNavigation.LineaDireccion2
                                        }
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Empleado>> GetEmpleadosSinClienteSinOficina()
    {
        return await _context.Empleados
                                    .Include(e => e.Clientes)
                                    .Include(e => e.CodigoOficinaNavigation)
                                    .Where(e => !e.Clientes.Any() && e.CodigoOficinaNavigation == null)
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Empleado>> GetEmpleadosSinClienteSinJefe()
    {
        return await _context.Empleados
                                    .Include(e => e.Clientes)
                                    .Include(e => e.CodigoOficinaNavigation)
                                    .Where(e => !e.Clientes.Any() && e.CodigoJefe == null)
                                    .ToListAsync();
    }
    public async Task<TotalEmpleados> GetTotalEmpleados()
    {
        var total = await _context.Empleados.CountAsync();
        var totalEmpleadosDto = new TotalEmpleados
        {
            Total = total
        };
        return totalEmpleadosDto;
    }
    public async Task<IEnumerable<RepVentasConClientes>> GetRepVentasConCantidadClientes()
    {
        return await _context.Empleados
                                    .Include(p => p.Clientes)
                                    .Where(e => e.Clientes.Any(p => p.CodigoEmpleadoRepVentasNavigation != null))
                                    .Select(p => new RepVentasConClientes
                                    {
                                        Nombre = p.Nombre,
                                        Apellidol = p.Apellidol,
                                        Apellido2 = p.Apellido2,
                                        CantidadClientes = p.Clientes.Count()
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<EmpleadosTelefonoOficina>> GetRepVentasSinCliente()
    {
        var clientesConRepVentas = await _context.Clientes.Select(p => p.CodigoEmpleadoRepVentas).Distinct().ToListAsync();
        var RepVentas = await _context.Empleados.Where(p => !clientesConRepVentas.Contains(p.CodigoEmpleado))
                                                .Select(p => new EmpleadosTelefonoOficina
                                                {
                                                    Nombre = p.Nombre,
                                                    Apellidol = p.Apellidol,
                                                    Apellido2 = p.Apellido2,
                                                    Puesto = p.Puesto,
                                                    Telefono = p.CodigoOficinaNavigation.Telefono
                                                })
                                                .ToListAsync();
        return RepVentas;
    }
    public async Task<IEnumerable<EmpleadosTelefonoOficina>> GetNoRepVentaDeClientes()
    {
        return await _context.Empleados
                                    .Where(p => !p.Clientes.Any())
                                    .Select(p => new EmpleadosTelefonoOficina
                                    {
                                        Nombre = p.Nombre,
                                        Apellidol = p.Apellidol,
                                        Apellido2 = p.Apellido2,
                                        Puesto = p.Puesto,
                                        Telefono = p.CodigoOficinaNavigation.Telefono
                                    })
                                    .ToListAsync();
    }
}
