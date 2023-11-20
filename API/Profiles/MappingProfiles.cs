using System.Linq;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Views;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<DetallePedido, DetallePedidoDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<GamaProducto, GamaProductoDto>().ReverseMap();
            CreateMap<Oficina, OficinaDto>().ReverseMap();
            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();

            //Consultas

            CreateMap<Pedido, EstadosPedidosDto>().ReverseMap();
            CreateMap<Cliente, CodigoPago2008Dto>().ReverseMap();
            CreateMap<Pedido, NoEntregadosATiempoDto>().ReverseMap();
            CreateMap<Pago, FormaPagoDto>().ReverseMap();
            CreateMap<Cliente, ClienteConRepresentanteDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoNombresDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoNombresOficinaDto>().ReverseMap();
            CreateMap<Cliente, ClienteRepresentanteOficinaDto>().ReverseMap();
            CreateMap<Oficina, OficinaCiudadDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoJefeJefeDto>().ReverseMap();
            CreateMap<Cliente, ClienteNombreDto>().ReverseMap();
            CreateMap<ClienteGama, ClienteGamaDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoOficinaDto>().ReverseMap();
            CreateMap<Producto, ProductoGamaDto>().ReverseMap();
            CreateMap<ClientesPorPais, ClientesPorPaisDto>().ReverseMap();
            CreateMap<PedidoPorEstado, PedidosPorEstadoDto>().ReverseMap();
            CreateMap<ClientePorCiudad, ClientePorCiudadDto>().ReverseMap();
            CreateMap<RepVentasConClientes, RepVentasConClientesDto>().ReverseMap();
            CreateMap<TotalEmpleados, TotalEmpleadosDto>().ReverseMap();
            CreateMap<TotalCliente, TotalClientesDto>().ReverseMap();
            CreateMap<ClientePagos, ClientePagosDto>().ReverseMap();
            CreateMap<PedidosConCantidadProductos, PedidosConCantidadProductosDto>().ReverseMap();
            CreateMap<PedidosConSumaCantidadTotal, PedidosConSumaCantidaTotalDto>().ReverseMap();
            CreateMap<ProductosMasVendidos, ProductosMasVendidosDto>().ReverseMap();
            CreateMap<TotalFacturadoProductos, TotalFacturadoProductosDto>().ReverseMap();
            CreateMap<TotalPagosPorAnyo, TotalPagosPorAnyoDto>().ReverseMap();
        }
    }
}