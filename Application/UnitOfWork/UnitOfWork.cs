using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JardineriaContext context;
        private IUser _user;
        private IRol _rol;
        private ICliente _cliente;
        private IDetallePedido _detallePedido;
        private IEmpleado _empleado;
        private IGamaProducto _gamaProducto;
        private IOficina _oficina;
        private IPago _pago;
        private IPedido _pedido;
        private IProducto _producto;
        private IProveedor _proveedor;
        private IProveedorProducto _proveedorProducto;

        public UnitOfWork(JardineriaContext _context)
        {
            context = _context;
        }

        public IUser Users
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(context);
                }
                return _user;
            }
        }
        public IRol Rols
        {
            get
            {
                if (_rol == null)
                {
                    _rol = new RolRepository(context);
                }
                return _rol;
            }
        }

        public ICliente Clientes
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = new ClienteRepository(context);
                }
                return _cliente;
            }
        }
        public IDetallePedido DetallePedidos
        {
            get
            {
                if (_detallePedido == null)
                {
                    _detallePedido = new DetallePedidoRepository(context);
                }
                return _detallePedido;
            }
        }
        public IEmpleado Empleados
        {
            get
            {
                if (_empleado == null)
                {
                    _empleado = new EmpleadoRepository(context);
                }
                return _empleado;
            }
        }

        public IGamaProducto GamaProductos
        {
            get
            {
                if (_gamaProducto == null)
                {
                    _gamaProducto = new GamaProductoRepository(context);
                }
                return _gamaProducto;
            }
        }

        public IOficina Oficinas
        {
            get
            {
                if (_oficina == null)
                {
                    _oficina = new OficinaRepository(context);
                }
                return _oficina;
            }
        }

        public IPago Pagos
        {
            get
            {
                if (_pago == null)
                {
                    _pago = new PagoRepository(context);
                }
                return _pago;
            }
        }

        public IPedido Pedidos
        {
            get
            {
                if (_pedido == null)
                {
                    _pedido = new PedidoRepository(context);
                }
                return _pedido;
            }
        }

        public IProducto Productos
        {
            get
            {
                if (_producto == null)
                {
                    _producto = new ProductoRepository(context);
                }
                return _producto;
            }
        }

        public IProveedor Proveedors
        {
            get
            {
                if (_proveedor == null)
                {
                    _proveedor = new ProveedorRepository(context);
                }
                return _proveedor;
            }
        }

        public IProveedorProducto ProveedorProductos
        {
            get
            {
                if (_proveedorProducto == null)
                {
                    _proveedorProducto = new ProveedorProductoRepository(context);
                }
                return _proveedorProducto;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}