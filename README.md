# Jardineria

Los endpoints estan separados por:

- Los gets de cada tabla y su versionado.
- Los gets de las consultas

## Endpoints Usuarios

Para los endpoints de Register y AddRole es necesario estar autenticado con un usuario que tenga rol de "Administrator"

##### 1. Register

`/api/User/register`

Body en formato JSON

```JSON
{
  "email": "string",
  "username": "string",
  "password": "string"
}
```

##### 2. Login

Aca obtenemos el token para usarlo como autenticación en el Bearer Token de las consultas

`/api/User/token`

Body en formato JSON

```JSON
{
  "username": "string",
  "password": "string"
}
```

##### 2. AddRole

`/api/User/addrole`

Body en formato JSON

```JSON
{
  "username": "string",
  "password": "string",
  "role": "string"
}
```

## Endpoints consultas

1. Devuelve un listado con el nombre de los todos los clientes españoles.

`/api/Cliente/GetClientesEspañoles`

2.  Devuelve un listado con los distintos estados por los que puede pasar un
    pedido.

`/api/Pedido/GetDistintosEstados`

3.  Devuelve un listado con el código de cliente de aquellos clientes que
    realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar
    aquellos códigos de cliente que aparezcan repetidos.

`/api/Cliente/GetCodigoPago2008`

4.  Devuelve un listado con el código de pedido, código de cliente, fecha
    esperada y fecha de entrega de los pedidos que no han sido entregados a
    tiempo.

`/api/Pedido/GetNoEntregadosATiempo`

5.  Devuelve un listado con el código de pedido, código de cliente, fecha
    esperada y fecha de entrega de los pedidos cuya fecha de entrega ha sido al
    menos dos días antes de la fecha esperada.

`/api/Pedido/GetNoEntregadosATiempov2`

6.  Devuelve un listado de todos los pedidos que fueron rechazados en 2009.

`/api/Pedido/GetPedidosRechazados`

7.  Devuelve un listado de todos los pedidos que han sido entregados en el
    mes de enero de cualquier año.

`/api/Pedido/GetPedidosEntregadosEnero`

8.  Devuelve un listado con todos los pagos que se realizaron en el
    año 2008 mediante Paypal. Ordene el resultado de mayor a menor.

`/api/Pago/GetPagos2008Paypal`

9.  Devuelve un listado con todas las formas de pago que aparecen en la
    tabla pago. Tenga en cuenta que no deben aparecer formas de pago
    repetidas.

`/api/Pago/GetFormasPago`

10. Devuelve un listado con todos los productos que pertenecen a la
    gama Ornamentales y que tienen más de 100 unidades en stock. El listado
    deberá estar ordenado por su precio de venta, mostrando en primer lugar
    los de mayor precio.

`/api/Producto/GetOrnamentalesStock100`

11. Devuelve un listado con todos los clientes que sean de la ciudad de Madrid y
    cuyo representante de ventas tenga el código de empleado 11 o 30.

`/api/Cliente/GetClientesMadridRep11o30`

12. Obtén un listado con el nombre de cada cliente y el nombre y apellido de su
    representante de ventas.

`/api/Cliente/GetClienteRepresentanteVenta`

13. Muestra el nombre de los clientes que hayan realizado pagos junto con el
    nombre de sus representantes de ventas.

`/api/Cliente/GetClienteRepresentanteVentaPago`

14. Muestra el nombre de los clientes que no hayan realizado pagos junto con
    el nombre de sus representantes de ventas.

`/api/Cliente/GetClienteRepresentanteVentaNoPago`

15. Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus
    representantes junto con la ciudad de la oficina a la que pertenece el
    representante.

`/api/Cliente/GetClienteRepresentanteVentaPagoOficina`

16. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre
    de sus representantes junto con la ciudad de la oficina a la que pertenece el
    representante.

`/api/Cliente/GetClienteRepresentanteVentaNoPagoOficina`

17. Devuelve un listado que muestre el nombre de cada empleados, el nombre
    de su jefe y el nombre del jefe de sus jefe.

`/api/Empleado/GetEmpleadosJefeDelJefe`

18. Devuelve el nombre de los clientes a los que no se les ha entregado a
    tiempo un pedido.

`/api/Cliente/GetClientePedidoEntregadoTarde`

19. Devuelve un listado de las diferentes gamas de producto que ha comprado
    cada cliente.

`/api/Cliente/GetGamaProductosxCliente`

20. Devuelve un listado que muestre solamente los clientes que no han
    realizado ningún pago.

`/api/Cliente/GetClientesNoHanPagado`

21. Devuelve un listado que muestre los clientes que no han realizado ningún
    pago y los que no han realizado ningún pedido.

`/api/Cliente/GetClientesNoHanPagadoNiPedido`

22. Devuelve un listado que muestre solamente los empleados que no tienen un
    cliente asociado junto con los datos de la oficina donde trabajan.

`/api/Empleado/GetEmpleadosSinClienteConOficina`

23. Devuelve un listado que muestre los empleados que no tienen una oficina
    asociada y los que no tienen un cliente asociado.

`/api/Empleado/GetEmpleadosSinClienteSinOficina`

24. Devuelve un listado de los productos que nunca han aparecido en un
    pedido.

`/api/Producto/GetProductosSinPedido`

25. Devuelve un listado de los productos que nunca han aparecido en un
    pedido. El resultado debe mostrar el nombre, la descripción y la imagen del
    producto.

`/api/Producto/GetProductosGamaSinPedido`

26. Devuelve las oficinas donde no trabajan ninguno de los empleados que
    hayan sido los representantes de ventas de algún cliente que haya realizado
    la compra de algún producto de la gama Frutales.

`/api/Oficina/GetOficinasNoTrabajanRepresentantes`

27. Devuelve un listado con los clientes que han realizado algún pedido pero no
    han realizado ningún pago.

`/api/Cliente/GetClientesHanPagadoNoPedido`

28. Devuelve un listado con los datos de los empleados que no tienen clientes
    asociados y el nombre de su jefe asociado.

`/api/Empleado/GetEmpleadosSinClienteSinJefe`

29. ¿Cuántos empleados hay en la compañía?

`/api/Empleado/GetTotalEmpleados`

30. ¿Cuántos clientes tiene cada país?

`/api/Cliente/GetClientesPorPais`

31. ¿Cuál fue el pago medio en 2009?

`/api/Pago/GetPagoMedio`

32. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma
    descendente por el número de pedidos.

`/api/Pedido/GetPedidoPorEstados`

33. ¿Cuántos clientes existen con domicilio en la ciudad de Madrid?

`/api/Cliente/GetClientesPorCiudad`

34. ¿Calcula cuántos clientes tiene cada una de las ciudades que empiezan
    por M?

`/api/Cliente/GetClientesPorCiudadM`

35. Devuelve el nombre de los representantes de ventas y el número de clientes
    al que atiende cada uno.

`/api/Empleado/GetRepVentasConCantidadClientes`

36. Calcula el número de clientes que no tiene asignado representante de
    ventas.

`/api/Cliente/GetTotalClientesSinRep`

37. Calcula la fecha del primer y último pago realizado por cada uno de los
    clientes. El listado deberá mostrar el nombre y los apellidos de cada cliente.

`/api/Cliente/GetPrimerUltimoPago`

38. Calcula el número de productos diferentes que hay en cada uno de los
    pedidos.

`/api/Pedido/GetPedidoConCantidadProductos`

39. Calcula la suma de la cantidad total de todos los productos que aparecen en
    cada uno de los pedidos.

`/api/Pedido/GetPedidosConSumaCantidadTotal`

40. Devuelve un listado de los 20 productos más vendidos y el número total de
    unidades que se han vendido de cada uno. El listado deberá estar ordenado
    por el número total de unidades vendidas.

`/api/Producto/GetProductosMasVendidos`

41. La misma información que en la pregunta anterior, pero agrupada por
    código de producto.

`/api/Producto/GetProductosMasVendidosAgrupadosCodigo`

42. La misma información que en la pregunta anterior, pero agrupada por
    código de producto filtrada por los códigos que empiecen por OR.

`/api/Producto/GetProductosMasVendidosAgrupadosCodigoFiltradoOr`

43. Lista las ventas totales de los productos que hayan facturado más de 3000
    euros. Se mostrará el nombre, unidades vendidas, total facturado y total
    facturado con impuestos (21% IVA).

`/api/Producto/GetProductosVentasMas3000`

44. Muestre la suma total de todos los pagos que se realizaron para cada uno
    de los años que aparecen en la tabla pagos.

`/api/Pago/GetTotalPagosPorAnyos`

45. Devuelve el nombre del cliente con mayor límite de crédito.

`/api/Cliente/GetClienteMayorLimiteCreditoV2`

46. Devuelve el nombre del producto que tenga el precio de venta más caro.

`/api/Producto/GetProductoPrecioVentaMasCaroV2`

47. Devuelve el nombre del producto del que se han vendido más unidades.
    (Tenga en cuenta que tendrá que calcular cuál es el número total de
    unidades que se han vendido de cada producto a partir de los datos de la
    tabla detalle_pedido).

`/api/Producto/GetProductosMasUnidadesVendidas`

48. Los clientes cuyo límite de crédito sea mayor que los pagos que haya
    realizado. (Sin utilizar INNER JOIN).

`/api/Cliente/GetClienteCreditoMayorPagoRealizado`

49. Devuelve el nombre del cliente con mayor límite de crédito.

`/api/Cliente/GetClienteMayorLimiteCredito`

50. Devuelve el nombre del producto que tenga el precio de venta más caro.

`/api/Producto/GetProductoPrecioVentaMasCaro`

51. Devuelve un listado que muestre solamente los clientes que no han
    realizado ningún pago

`/api/Cliente/GetClientesNoHanPagadoV2`

52. Devuelve un listado que muestre solamente los clientes que sí han realizado
    algún pago.

`/api/Cliente/GetClientesSiHanPagado`

53. Devuelve un listado de los productos que nunca han aparecido en un
    pedido.

`/api/Producto/GetProductosSinPedidoV2`

54. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos
    empleados que no sean representante de ventas de ningún cliente.

`/api/Empleado/GetRepVentasSinCliente`

55. Devuelve un listado que muestre solamente los clientes que no han
    realizado ningún pago.

`/api/Cliente/GetClientesNoHanPagadoV3`

56. Devuelve un listado que muestre solamente los clientes que sí han realizado
    algún pago.

`/api/Cliente/GetClientesSiHanPagadoV2`

57. Devuelve el listado de clientes indicando el nombre del cliente y cuántos
    pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no
    han realizado ningún pedido.

`/api/Cliente/GetClientesxPedido`

58. Devuelve el nombre de los clientes que hayan hecho pedidos en 2008
    ordenados alfabéticamente de menor a mayor.

`/api/Cliente/GetClientesPedidos2008`

59. Devuelve el nombre del cliente, el nombre y primer apellido de su
    representante de ventas y el número de teléfono de la oficina del
    representante de ventas, de aquellos clientes que no hayan realizado ningún
    pago.

`/api/Cliente/GetClienteRepOficinaPagos`

60. Devuelve el listado de clientes donde aparezca el nombre del cliente, el
    nombre y primer apellido de su representante de ventas y la ciudad donde
    está su oficina.

`/api/Cliente/GetClienteRepCiudadOficinas`

61. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos
    empleados que no sean representante de ventas de ningún cliente.

`/api/Empleado/GetNoRepVentaDeClientes`

### Consultas Paginadas

#### En el Header agregar

X-Version: 1.1

`/api/Cliente/GetClientesEspañoles`

`/api/Cliente/GetClientesMadridRep11o30`

`/api/Cliente/GetClientePedidoEntregadoTarde`

`/api/Cliente/GetClientesPedidos2008`
