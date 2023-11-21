using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
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
    public async Task<IEnumerable<Cliente>> GetClientesMadridRep11o30()
    {
        return await _context.Clientes
                                    .Where(p => p.Ciudad.ToLower() == "Madrid".ToLower() && p.CodigoEmpleadoRepVentas == 11 || p.CodigoEmpleadoRepVentas == 30)
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClienteRepresentanteVenta()
    {
        return await _context.Clientes
                                    .Include(p => p.CodigoEmpleadoRepVentasNavigation)
                                    .Select(p => new Cliente
                                    {
                                        NombreCliente = p.NombreCliente,
                                        CodigoEmpleadoRepVentasNavigation = new Empleado
                                        {
                                            Nombre = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                            Apellidol = p.CodigoEmpleadoRepVentasNavigation.Apellidol,
                                            Apellido2 = p.CodigoEmpleadoRepVentasNavigation.Apellido2
                                        }
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaPago()
    {
        return await _context.Clientes
                                    .Include(p => p.CodigoEmpleadoRepVentasNavigation)
                                    .Include(p => p.Pagos)
                                    .Where(p => p.Pagos.Any())
                                    .Select(p => new Cliente
                                    {
                                        NombreCliente = p.NombreCliente,
                                        CodigoEmpleadoRepVentasNavigation = new Empleado
                                        {
                                            Nombre = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                            Apellidol = p.CodigoEmpleadoRepVentasNavigation.Apellidol,
                                            Apellido2 = p.CodigoEmpleadoRepVentasNavigation.Apellido2
                                        }
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaNoPago()
    {
        return await _context.Clientes
                                    .Include(p => p.CodigoEmpleadoRepVentasNavigation)
                                    .Include(p => p.Pagos)
                                    .Where(p => !p.Pagos.Any())
                                    .Select(p => new Cliente
                                    {
                                        NombreCliente = p.NombreCliente,
                                        CodigoEmpleadoRepVentasNavigation = new Empleado
                                        {
                                            Nombre = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                            Apellidol = p.CodigoEmpleadoRepVentasNavigation.Apellidol,
                                            Apellido2 = p.CodigoEmpleadoRepVentasNavigation.Apellido2
                                        }
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaPagoOficina()
    {
        return await _context.Clientes
                                    .Include(p => p.Pagos)
                                    .Include(p => p.CodigoEmpleadoRepVentasNavigation)
                                    .ThenInclude(p => p.CodigoOficinaNavigation)
                                    .Where(p => p.Pagos.Any() && p.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.CodigoOficina == p.CodigoEmpleadoRepVentasNavigation.CodigoOficina)
                                    .Select(p => new Cliente
                                    {
                                        NombreCliente = p.NombreCliente,
                                        CodigoEmpleadoRepVentasNavigation = new Empleado
                                        {
                                            Nombre = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                            Apellidol = p.CodigoEmpleadoRepVentasNavigation.Apellidol,
                                            Apellido2 = p.CodigoEmpleadoRepVentasNavigation.Apellido2,
                                            CodigoOficinaNavigation = new Oficina
                                            {
                                                Ciudad = p.Ciudad
                                            }
                                        }
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaNoPagoOficina()
    {
        return await _context.Clientes
                                    .Include(p => p.Pagos)
                                    .Include(p => p.CodigoEmpleadoRepVentasNavigation)
                                    .ThenInclude(p => p.CodigoOficinaNavigation)
                                    .Where(p => !p.Pagos.Any() && p.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.CodigoOficina == p.CodigoEmpleadoRepVentasNavigation.CodigoOficina)
                                    .Select(p => new Cliente
                                    {
                                        NombreCliente = p.NombreCliente,
                                        CodigoEmpleadoRepVentasNavigation = new Empleado
                                        {
                                            Nombre = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                            Apellidol = p.CodigoEmpleadoRepVentasNavigation.Apellidol,
                                            Apellido2 = p.CodigoEmpleadoRepVentasNavigation.Apellido2,
                                            CodigoOficinaNavigation = new Oficina
                                            {
                                                Ciudad = p.Ciudad
                                            }
                                        }
                                    })
                                    .ToListAsync();

    }
    public async Task<IEnumerable<Cliente>> GetClientePedidoEntregadoTarde()
    {
        return await _context.Clientes
                                    .Include(p => p.Pedidos)
                                    .Where(p => p.Pedidos.Any(p => p.FechaEsperada < p.FechaEntrega))
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ClienteGama>> GetGamaProductosxCliente()
    {
        return await _context.Clientes
                                .Include(c => c.Pedidos)
                                .ThenInclude(p => p.DetallePedidos)
                                .ThenInclude(dp => dp.CodigoProductoNavigation)
                                .ThenInclude(pr => pr.GamaNavigation)

                                .Select(c => new ClienteGama
                                {
                                    NombreCliente = c.NombreCliente,
                                    GamasCompradas = c.Pedidos
                                        .SelectMany(p => p.DetallePedidos)
                                        .Select(dp => dp.CodigoProductoNavigation.GamaNavigation)
                                        .Distinct()
                                        .ToList()
                                })
                                .ToListAsync();


    }

    public async Task<IEnumerable<Cliente>> GetClientesNoHanPagado()
    {
        return await _context.Clientes
                                .Where(cliente => !_context.Pagos.Any(pago => pago.CodigoCliente == cliente.CodigoCliente))
                                .ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClientesNoHanPagadoNiPedido()
    {
        return await _context.Clientes
                                        .Include(p => p.Pedidos)
                                        .Include(p => p.Pagos)
                                        .Where(p => !p.Pagos.Any() && !p.Pedidos.Any())
                                        .ToListAsync();
    }

    public async Task<IEnumerable<Cliente>> GetClientesHanPagadoNoPedido()
    {
        return await _context.Clientes
                                .Include(p => p.Pedidos)
                                .Include(p => p.Pagos)
                                .Where(p => p.Pagos.Any() && !p.Pedidos.Any())
                                .ToListAsync();
    }
    public async Task<IEnumerable<ClientesPorPais>> GetClientesPorPais()
    {
        return await _context.Clientes
                                    .GroupBy(p => p.Pais)
                                    .Select(p => new ClientesPorPais
                                    {
                                        Pais = p.Key,
                                        CantidadClientes = p.Count()
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ClientePorCiudad>> GetClientesPorCiudad()
    {
        return await _context.Clientes
                                    .GroupBy(p => p.Ciudad)
                                    .Select(p => new ClientePorCiudad
                                    {
                                        Ciudad = p.Key,
                                        CantidadClientes = p.Count()
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ClientePorCiudad>> GetClientesPorCiudadM()
    {
        return await _context.Clientes
                            .Where(p => p.Ciudad.StartsWith("M"))
                            .GroupBy(p => p.Ciudad)
                            .Select(p => new ClientePorCiudad
                            {
                                Ciudad = p.Key,
                                CantidadClientes = p.Count()
                            })
                            .ToListAsync();
    }
    public async Task<TotalCliente> GetTotalClientesSinRep()
    {
        var total = await _context.Clientes.Where(p => p.CodigoEmpleadoRepVentas == null).CountAsync();

        var resultado = new TotalCliente
        {
            CantidadClientes = total
        };
        return resultado;
    }

    public async Task<IEnumerable<ClientePagos>> GetPrimerUltimoPago()
    {
        return await _context.Clientes
                                    .Include(p => p.Pagos)
                                    .Select(p => new ClientePagos
                                    {
                                        NombreCliente = p.NombreCliente,
                                        NombreContacto = p.NombreContacto,
                                        ApellidoContacto = p.ApellidoContacto,
                                        PrimerPago = p.Pagos.Min(p => p.FechaPago),
                                        UltimoPago = p.Pagos.Max(p => p.FechaPago)
                                    })
                                    .ToListAsync();
    }
    public async Task<Cliente> GetClienteMayorLimiteCredito()
    {
        return await _context.Clientes
                                    .OrderByDescending(p => p.LimiteCredito)
                                    .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClienteCreditoMayorPagoRealizado()
    {
        return await _context.Clientes
                                    .Where(p => p.LimiteCredito > p.Pagos.Sum(p => p.Total)).ToListAsync();
    }
    public async Task<Cliente> GetClienteMayorLimiteCreditoV2()
    {
        var nombreCliente = await _context.Clientes
                                            .Where(cliente => cliente.LimiteCredito >=
                                            _context.Clientes.Max(c => c.LimiteCredito))
                                            .FirstOrDefaultAsync();
        return nombreCliente;
    }
    public async Task<IEnumerable<Cliente>> GetClientesNoHanPagadoV2()
    {
        var codigosClientesConPagos = await _context.Pagos
                                                .Select(p => p.CodigoCliente)
                                                .Distinct()
                                                .ToListAsync();

        var clientesSinPagos = await _context.Clientes
                                        .Where(cliente => !codigosClientesConPagos.Contains(cliente.CodigoCliente))
                                        .ToListAsync();

        return clientesSinPagos;
    }
    public async Task<IEnumerable<Cliente>> GetClientesSiHanPagado()
    {
        var codigosClientesConPagos = await _context.Pagos
                                        .Select(p => p.CodigoCliente)
                                        .Distinct()
                                        .ToListAsync();

        var clientesConPagos = await _context.Clientes
                                        .Where(cliente => codigosClientesConPagos.Contains(cliente.CodigoCliente))
                                        .ToListAsync();

        return clientesConPagos;
    }
    public async Task<IEnumerable<Cliente>> GetClientesNoHanPagadoV3()
    {

        return await _context.Clientes.Include(p => p.Pagos).Where(p => !p.Pagos.Any()).ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClientesSiHanPagadoV2()
    {
        return await _context.Clientes
                                    .Where(cliente => _context.Pagos
                                        .Any(pago => pago.CodigoCliente == cliente.CodigoCliente))
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ClientesxPedido>> GetClientesxPedido()
    {
        return await _context.Clientes
                                    .Select(p => new ClientesxPedido
                                    {
                                        Nombre = p.NombreCliente,
                                        CantidadPedidos = p.Pedidos.Sum(p => p.CodigoCliente)
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Cliente>> GetClientesPedidos2008()
    {
        return await _context.Clientes
                                    .Where(p => p.Pedidos.Any(p => p.FechaPedido.Year == 2008))
                                    .OrderBy(p => p.NombreCliente)
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ClienteRepOficinaPago>> GetClienteRepOficinaPagos()
    {
        return await _context.Clientes
                                    .Where(p => !p.Pagos.Any())
                                    .Select(p => new ClienteRepOficinaPago
                                    {
                                        NombreCliente = p.NombreCliente,
                                        NombreEmpleado = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                        ApellidoEmpleado = p.CodigoEmpleadoRepVentasNavigation.Apellidol,
                                        TelefonoOficina = p.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.Telefono
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ClienteRepCiudadOficina>> GetClienteRepCiudadOficinas()
    {
        return await _context.Clientes
                                    .Select(p => new ClienteRepCiudadOficina
                                    {
                                        NombreCliente = p.NombreCliente,
                                        NombreEmpleado = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                        ApellidoEmpleado = p.CodigoEmpleadoRepVentasNavigation.Apellidol,
                                        CiudadOficina = p.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.Ciudad
                                    })
                                    .ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetClientesEspañoles(int pageIndex, int pageSize, string search)
    {
        var query = _context.Clientes as IQueryable<Cliente>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreCliente.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Where(p => p.Pais.ToLower() == "Spain".ToLower())
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
    public async Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetClientesMadridRep11o30(int pageIndex, int pageSize, string search)
    {
        var query = _context.Clientes as IQueryable<Cliente>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreCliente.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Where(p => p.Ciudad.ToLower() == "Madrid".ToLower() && p.CodigoEmpleadoRepVentas == 11 || p.CodigoEmpleadoRepVentas == 30)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
    public async Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetClientePedidoEntregadoTarde(int pageIndex, int pageSize, string search)
    {
        var query = _context.Clientes as IQueryable<Cliente>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreCliente.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Pedidos)
                                .Where(p => p.Pedidos.Any(p => p.FechaEsperada < p.FechaEntrega))
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
    public async Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetClientesPedidos2008(int pageIndex, int pageSize, string search)
    {
        var query = _context.Clientes as IQueryable<Cliente>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreCliente.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Where(p => p.Pedidos.Any(p => p.FechaPedido.Year == 2008))
                                .OrderBy(p => p.NombreCliente)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
}