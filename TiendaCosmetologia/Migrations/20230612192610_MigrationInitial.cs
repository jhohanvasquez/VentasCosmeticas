using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentaCosmeticos.Migrations
{
    public partial class MigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartamentoVenta",
                columns: table => new
                {
                    idDepartamentoVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    esActivo = table.Column<bool>(type: "bit", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__8A3D240CE670682C", x => x.idDepartamentoVenta);
                });

            migrationBuilder.CreateTable(
                name: "NumeroDocumento",
                columns: table => new
                {
                    idNumeroDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ultimo_Numero = table.Column<int>(type: "int", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NumeroDo__471E421A78999DD9", x => x.idNumeroDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    idRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    esActivo = table.Column<bool>(type: "bit", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__3C872F7670BFFF74", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    idVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroDocumento = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    tipoPago = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venta__077D561409C275F1", x => x.idVenta);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    idDepartamentoVenta = table.Column<int>(type: "int", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    esActivo = table.Column<bool>(type: "bit", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__07F4A1323E322568", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK__Producto__idCate__1BFD2C07",
                        column: x => x.idDepartamentoVenta,
                        principalTable: "DepartamentoVenta",
                        principalColumn: "idDepartamentoVenta");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreApellidos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    correo = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    idRol = table.Column<int>(type: "int", nullable: true),
                    clave = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    esActivo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A61F6FD7E7", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__idRol__164452B1",
                        column: x => x.idRol,
                        principalTable: "Rol",
                        principalColumn: "idRol");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    idDetalleVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idVenta = table.Column<int>(type: "int", nullable: true),
                    idProducto = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleV__BFE2843FA3FFCC43", x => x.idDetalleVenta);
                    table.ForeignKey(
                        name: "FK__DetalleVe__idPro__267ABA7A",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto");
                    table.ForeignKey(
                        name: "FK__DetalleVe__idVen__25869641",
                        column: x => x.idVenta,
                        principalTable: "Venta",
                        principalColumn: "idVenta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_idProducto",
                table: "DetalleVenta",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_idVenta",
                table: "DetalleVenta",
                column: "idVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idDepartamentoVenta",
                table: "Producto",
                column: "idDepartamentoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idRol",
                table: "Usuario",
                column: "idRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "NumeroDocumento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "DepartamentoVenta");
        }
    }
}
