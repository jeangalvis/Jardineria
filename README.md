# Jardineria

Los endpoints estan separados por:

- Los gets de cada tabla y su versionado.
- Los gets de las consultas y su versionado.

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
