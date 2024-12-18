﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebSiteWasi.Migrations
{
    /// <inheritdoc />
    public partial class wasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagos",
                columns: table => new
                {
                    IdMetodoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMetodoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagos", x => x.IdMetodoPago);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    IdCarrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacionCarrito = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.IdCarrito);
                    table.ForeignKey(
                        name: "FK_Carritos_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockProducto = table.Column<int>(type: "int", nullable: false),
                    ImagenURLProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacionProducto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalProductoCompra = table.Column<int>(type: "int", nullable: false),
                    TotalCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContactoCompra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoCompra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionCompra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacionCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMetodoPago = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compra_MetodoPago",
                        column: x => x.IdMetodoPago,
                        principalTable: "MetodoPagos",
                        principalColumn: "IdMetodoPago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoProductos",
                columns: table => new
                {
                    IdCarritoProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdCarrito = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProductos", x => x.IdCarritoProducto);
                    table.ForeignKey(
                        name: "FK_CarritoProductos_Carritos_IdCarrito",
                        column: x => x.IdCarrito,
                        principalTable: "Carritos",
                        principalColumn: "IdCarrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoProductos_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompras",
                columns: table => new
                {
                    IdDetalleCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadDetalleCompra = table.Column<int>(type: "int", nullable: false),
                    TotalDetalleCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompras", x => x.IdDetalleCompra);
                    table.ForeignKey(
                        name: "FK_DetalleCompras_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompras_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "465b3eb9-18a6-46f6-9b9d-2e2f8cf482e8", null, "ADMIN", "ADMIN" },
                    { "e681a996-39e3-43d4-9b57-f59468c192e3", null, "CLIENT", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "NombreCategoria" },
                values: new object[,]
                {
                    { 1, "Electrónica" },
                    { 2, "Ropa y Moda" },
                    { 3, "Videojuegos" },
                    { 4, "Bebidas" },
                    { 5, "Comidas" }
                });

            migrationBuilder.InsertData(
                table: "MetodoPagos",
                columns: new[] { "IdMetodoPago", "NombreMetodoPago" },
                values: new object[,]
                {
                    { 1, "EFECTIVO" },
                    { 2, "TARJETA" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "DescripcionProducto", "FechaCreacionProducto", "IdCategoria", "ImagenURLProducto", "NombreProducto", "PrecioProducto", "StockProducto" },
                values: new object[,]
                {
                    { 1, "Pantalla AMOLED de 6.2 pulgadas, 128GB", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1516), 1, "Smartphone_Galaxy_S21.webp", "Smartphone Galaxy S21", 799.99m, 50 },
                    { 2, "Intel i5, 8GB RAM, 256GB SSD", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1528), 1, "Laptop_Dell_Inspiron_15.png", "Laptop Dell Inspiron 15", 699.99m, 40 },
                    { 3, "Pantalla Retina de 10.9 pulgadas, 64GB", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1530), 1, "Tablet_iPad_10th_Gen.png", "Tablet iPad 10th Gen", 499.99m, 30 },
                    { 4, "Cancelación de ruido, batería 30 horas", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1531), 1, "Audífonos_Bluetooth_Sony_WH_1000XM4.jfif", "Audífonos Bluetooth Sony WH-1000XM4", 349.99m, 60 },
                    { 5, "Resolución 3840 x 2160, HDR10+", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1533), 1, "Televisor_Samsung_4K_UHD_50.webp", "Televisor Samsung 4K UHD 50'' ", 599.99m, 25 },
                    { 6, "Transpirable, 100% poliéster, color negro", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1534), 2, "Camiseta_Nike_negra.png", "Camiseta Deportiva Nike ", 29.99m, 150 },
                    { 7, "Levis 501 Corte clásico, azul índigo", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1535), 2, "Pantalon_Jeans.png", "Pantalón Jeans ", 59.99m, 120 },
                    { 8, "Suela amortiguada, color blanco", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1537), 2, "Zapatillas.webp", "Zapatillas Adidas", 99.99m, 30 },
                    { 9, "Material de lana, color gris", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1538), 2, "Sombrero_Fedora.webp", "Sombrero Fedora", 19.99m, 70 },
                    { 10, "Suave al tacto, color beige", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1540), 2, "BufandaCachemir.webp", "Bufanda Cachemir", 39.99m, 40 },
                    { 11, "Videojuego de acción y aventura hack and slash", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1541), 3, "God_of_war_3.png", "God of War 3", 129.99m, 20 },
                    { 12, "Simulación de fútbol publicado por Electronic Arts", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1542), 3, "FIFA_23.webp", "FIFA 23", 99.99m, 100 },
                    { 13, "Simulación de carreras de 2022 desarrollado por Polyphony Digital", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1544), 3, "Gran_Turismo_7.png", "GranTurismo 7", 89.99m, 125 },
                    { 14, "Consola, 1TB, incluye mando y juegos", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1545), 3, "PlayStation_5.png", "PlayStation 5", 599.99m, 100 },
                    { 15, "Consola, 1TB, incluye mando", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1546), 3, "Xbox_Series_X.png", "Xbox Series X", 449.99m, 100 },
                    { 16, "Coca Cola Personal Fría", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1548), 4, "CocaCola.png", "Coca Cola", 3.5m, 500 },
                    { 17, "Pepsi 1L Fría", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1549), 4, "Pepsi.png", "Pepsi", 8.99m, 600 },
                    { 18, "Agua San Luis Personal Sin Gas", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1550), 4, "SAN_LUIS.png", "Agua San Luis", 2.59m, 400 },
                    { 19, "IncaKola Personal Fría", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1551), 4, "IncaKola.png", "IncaKola", 3.50m, 500 },
                    { 20, "Corona Extra 500ml", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1553), 4, "Corona.png", "Corona Extra", 16.99m, 100 },
                    { 21, "Galletas de mantequilla en cada de lata", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1554), 5, "Galletas_caja_lata.webp", "Galletas", 20.99m, 100 },
                    { 22, "1 Pollo de brasa con papas fritas y ensalada", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1555), 5, "Pollo_brasa.png", "Pollito de brasa", 99.99m, 300 },
                    { 23, "Paneton Todinno Caja Grande", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1556), 5, "todino.png", "Paneton Todinno", 29.90m, 400 },
                    { 24, "Pavo al horno grande 12kg", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1558), 5, "Pavo.png", "Pavo al horno", 129.99m, 50 },
                    { 25, "Ensalada de Verdura fresas y saludables", new DateTime(2024, 11, 27, 9, 56, 0, 657, DateTimeKind.Local).AddTicks(1559), 5, "Ensalada.png", "Ensalada de Verduras", 19.90m, 120 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProductos_IdCarrito",
                table: "CarritoProductos",
                column: "IdCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProductos_IdProducto",
                table: "CarritoProductos",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdUsuario",
                table: "Carritos",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdMetodoPago",
                table: "Compras",
                column: "IdMetodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdUsuario",
                table: "Compras",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_IdCompra",
                table: "DetalleCompras",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_IdProducto",
                table: "DetalleCompras",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarritoProductos");

            migrationBuilder.DropTable(
                name: "DetalleCompras");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "MetodoPagos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
