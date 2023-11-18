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
