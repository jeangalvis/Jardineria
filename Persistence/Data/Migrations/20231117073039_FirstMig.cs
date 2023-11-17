using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterDatabase()
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "cliente",
            //     columns: table => new
            //     {
            //         id_cliente = table.Column<int>(type: "int", nullable: false),
            //         nombre_cliente = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         nombre_contacto = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         apellido_contacto = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         telefono = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         fax = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         linea_direccion1 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         linea_direccion2 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         ciudad = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         region = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         pais = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         codigo_postal = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         limite_credito = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.id_cliente);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "gama_producto",
            //     columns: table => new
            //     {
            //         id_gama = table.Column<int>(type: "int", nullable: false),
            //         descripcion_texto = table.Column<string>(type: "tinytext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         descripcion_html = table.Column<string>(type: "tinytext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         imagen = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.id_gama);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "oficina",
            //     columns: table => new
            //     {
            //         codigo_oficina = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         ciudad = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         pais = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         region = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         codigo_postal = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         telefono = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         linea_direccion1 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         linea_direccion2 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.codigo_oficina);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "pago",
            //     columns: table => new
            //     {
            //         codigo_pago = table.Column<int>(type: "int", nullable: false),
            //         forma_pago = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         id_transaccion = table.Column<int>(type: "int", nullable: true),
            //         fecha_pago = table.Column<DateTime>(type: "datetime", nullable: true),
            //         total = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.codigo_pago);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "proveedor",
            //     columns: table => new
            //     {
            //         id_proveedor = table.Column<int>(type: "int", nullable: false),
            //         nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.id_proveedor);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "rol",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Name = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_rol", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "user",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_user", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "producto",
            //     columns: table => new
            //     {
            //         codigo_producto = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         dimensiones = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         proveedor = table.Column<int>(type: "int", nullable: false),
            //         descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         cantidad_stock = table.Column<short>(type: "smallint", nullable: false),
            //         precio_actual = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
            //         id_gama = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.codigo_producto);
            //         table.ForeignKey(
            //             name: "fk_producto_gama_producto1",
            //             column: x => x.id_gama,
            //             principalTable: "gama_producto",
            //             principalColumn: "id_gama");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "empleado",
            //     columns: table => new
            //     {
            //         codigo_empleado = table.Column<int>(type: "int", nullable: false),
            //         nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         apellido1 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         apellido2 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         extension = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         codigo_jefe = table.Column<int>(type: "int", nullable: true),
            //         puesto = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         codigo_oficina = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.codigo_empleado);
            //         table.ForeignKey(
            //             name: "fk_empleado_jefe",
            //             column: x => x.codigo_jefe,
            //             principalTable: "empleado",
            //             principalColumn: "codigo_empleado");
            //         table.ForeignKey(
            //             name: "fk_empleado_oficina1",
            //             column: x => x.codigo_oficina,
            //             principalTable: "oficina",
            //             principalColumn: "codigo_oficina");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "refreshToken",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         IdUserfk = table.Column<int>(type: "int", nullable: false),
            //         Token = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //         Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //         Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_refreshToken", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_refreshToken_user_IdUserfk",
            //             column: x => x.IdUserfk,
            //             principalTable: "user",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "userRols",
            //     columns: table => new
            //     {
            //         IdUserfk = table.Column<int>(type: "int", nullable: false),
            //         IdRolfk = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_userRols", x => new { x.IdUserfk, x.IdRolfk });
            //         table.ForeignKey(
            //             name: "FK_userRols_rol_IdRolfk",
            //             column: x => x.IdRolfk,
            //             principalTable: "rol",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_userRols_user_IdUserfk",
            //             column: x => x.IdUserfk,
            //             principalTable: "user",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "proveedor_producto",
            //     columns: table => new
            //     {
            //         id_provprod = table.Column<int>(type: "int", nullable: false),
            //         precio_proveedor = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
            //         proveedor_id = table.Column<int>(type: "int", nullable: false),
            //         producto_codigo_producto = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.id_provprod);
            //         table.ForeignKey(
            //             name: "fk_proveedor_producto_producto1",
            //             column: x => x.producto_codigo_producto,
            //             principalTable: "producto",
            //             principalColumn: "codigo_producto");
            //         table.ForeignKey(
            //             name: "fk_proveedor_producto_proveedor1",
            //             column: x => x.proveedor_id,
            //             principalTable: "proveedor",
            //             principalColumn: "id_proveedor");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "pedido",
            //     columns: table => new
            //     {
            //         codigo_pedido = table.Column<int>(type: "int", nullable: false),
            //         fecha_pedido = table.Column<DateTime>(type: "datetime", nullable: true),
            //         fecha_esperada = table.Column<DateTime>(type: "datetime", nullable: true),
            //         fecha_entrega = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         estado = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         comentarios = table.Column<string>(type: "text", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         codigo_empleado = table.Column<int>(type: "int", nullable: false),
            //         codigo_cliente = table.Column<int>(type: "int", nullable: false),
            //         codigo_pago = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.codigo_pedido);
            //         table.ForeignKey(
            //             name: "fk_pedido_cliente1",
            //             column: x => x.codigo_cliente,
            //             principalTable: "cliente",
            //             principalColumn: "id_cliente");
            //         table.ForeignKey(
            //             name: "fk_pedido_empleado1",
            //             column: x => x.codigo_empleado,
            //             principalTable: "empleado",
            //             principalColumn: "codigo_empleado");
            //         table.ForeignKey(
            //             name: "fk_pedido_pago1",
            //             column: x => x.codigo_pago,
            //             principalTable: "pago",
            //             principalColumn: "codigo_pago");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "detalle_pedido",
            //     columns: table => new
            //     {
            //         id_detalle_pedido = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         cantidad = table.Column<int>(type: "int", nullable: true),
            //         precio_unidad = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
            //         numero_linea = table.Column<short>(type: "smallint", nullable: true),
            //         codigo_pedido = table.Column<int>(type: "int", nullable: false),
            //         codigo_producto = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.id_detalle_pedido);
            //         table.ForeignKey(
            //             name: "fk_detalle_pedido_pedido",
            //             column: x => x.codigo_pedido,
            //             principalTable: "pedido",
            //             principalColumn: "codigo_pedido");
            //         table.ForeignKey(
            //             name: "fk_detalle_pedido_producto1",
            //             column: x => x.codigo_producto,
            //             principalTable: "producto",
            //             principalColumn: "codigo_producto");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateIndex(
            //     name: "fk_detalle_pedido_pedido_idx",
            //     table: "detalle_pedido",
            //     column: "codigo_pedido");

            // migrationBuilder.CreateIndex(
            //     name: "fk_detalle_pedido_producto1_idx",
            //     table: "detalle_pedido",
            //     column: "codigo_producto");

            // migrationBuilder.CreateIndex(
            //     name: "fk_empleado_empleado1_idx",
            //     table: "empleado",
            //     column: "codigo_jefe");

            // migrationBuilder.CreateIndex(
            //     name: "fk_empleado_oficina1_idx",
            //     table: "empleado",
            //     column: "codigo_oficina");

            // migrationBuilder.CreateIndex(
            //     name: "fk_pedido_cliente1_idx",
            //     table: "pedido",
            //     column: "codigo_cliente");

            // migrationBuilder.CreateIndex(
            //     name: "fk_pedido_empleado1_idx",
            //     table: "pedido",
            //     column: "codigo_empleado");

            // migrationBuilder.CreateIndex(
            //     name: "fk_pedido_pago1_idx",
            //     table: "pedido",
            //     column: "codigo_pago");

            // migrationBuilder.CreateIndex(
            //     name: "fk_producto_gama_producto1_idx",
            //     table: "producto",
            //     column: "id_gama");

            // migrationBuilder.CreateIndex(
            //     name: "fk_proveedor_producto_producto1_idx",
            //     table: "proveedor_producto",
            //     column: "producto_codigo_producto");

            // migrationBuilder.CreateIndex(
            //     name: "fk_proveedor_producto_proveedor1_idx",
            //     table: "proveedor_producto",
            //     column: "proveedor_id");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_refreshToken_IdUserfk",
            //         table: "refreshToken",
            //         column: "IdUserfk");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_userRols_IdRolfk",
            //         table: "userRols",
            //         column: "IdRolfk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "detalle_pedido");

            // migrationBuilder.DropTable(
            //     name: "proveedor_producto");

            // migrationBuilder.DropTable(
            //     name: "refreshToken");

            // migrationBuilder.DropTable(
            //     name: "userRols");

            // migrationBuilder.DropTable(
            //     name: "pedido");

            // migrationBuilder.DropTable(
            //     name: "producto");

            // migrationBuilder.DropTable(
            //     name: "proveedor");

            // migrationBuilder.DropTable(
            //     name: "rol");

            // migrationBuilder.DropTable(
            //     name: "user");

            // migrationBuilder.DropTable(
            //     name: "cliente");

            // migrationBuilder.DropTable(
            //     name: "empleado");

            // migrationBuilder.DropTable(
            //     name: "pago");

            // migrationBuilder.DropTable(
            //     name: "gama_producto");

            // migrationBuilder.DropTable(
            //     name: "oficina");
        }
    }
}
