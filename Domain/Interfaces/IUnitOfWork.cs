namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUser Users { get; }
        IRol Rols { get; }
        ICliente Clientes { get; }
        IDetallePedido DetallePedidos { get; }
        IEmpleado Empleados { get; }
        IGamaProducto GamaProductos { get; }
        IOficina Oficinas { get; }
        IPago Pagos { get; }
        IPedido Pedidos { get; }
        IProducto Productos { get; }
        IProveedor Proveedors { get; }
        IProveedorProducto ProveedorProductos { get; }
        Task<int> SaveAsync();
    }
}