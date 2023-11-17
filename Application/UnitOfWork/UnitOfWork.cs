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