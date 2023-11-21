using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IEmpleado : IGeneric<Empleado>
    {
        Task<IEnumerable<Empleado>> GetEmpleadosJefeDelJefe();
        Task<IEnumerable<Empleado>> GetEmpleadosSinClienteConOficina();
        Task<IEnumerable<Empleado>> GetEmpleadosSinClienteSinOficina();
        Task<IEnumerable<Empleado>> GetEmpleadosSinClienteSinJefe();
        Task<TotalEmpleados> GetTotalEmpleados();
        Task<IEnumerable<RepVentasConClientes>> GetRepVentasConCantidadClientes();
        Task<IEnumerable<EmpleadosTelefonoOficina>> GetRepVentasSinCliente();
        Task<IEnumerable<EmpleadosTelefonoOficina>> GetNoRepVentaDeClientes();
    }
}