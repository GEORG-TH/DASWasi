﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebSiteWasi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "377bf535-e2fa-4299-a74d-b7bd00b13e4a",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "513b05ff-40ce-4ff0-879b-51bf51688899",
                            Name = "CLIENT",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebSiteWasi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebSiteWasi.Models.Carrito", b =>
                {
                    b.Property<int>("IdCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarrito"));

                    b.Property<DateTime>("FechaCreacionCarrito")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdCarrito");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Carritos");
                });

            modelBuilder.Entity("WebSiteWasi.Models.CarritoProducto", b =>
                {
                    b.Property<int>("IdCarritoProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarritoProducto"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdCarrito")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.HasKey("IdCarritoProducto");

                    b.HasIndex("IdCarrito");

                    b.HasIndex("IdProducto");

                    b.ToTable("CarritoProductos");
                });

            modelBuilder.Entity("WebSiteWasi.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            IdCategoria = 1,
                            NombreCategoria = "Electrónica"
                        },
                        new
                        {
                            IdCategoria = 2,
                            NombreCategoria = "Ropa y Moda"
                        },
                        new
                        {
                            IdCategoria = 3,
                            NombreCategoria = "Videojuegos"
                        },
                        new
                        {
                            IdCategoria = 4,
                            NombreCategoria = "Comidas"
                        },
                        new
                        {
                            IdCategoria = 5,
                            NombreCategoria = "Bebidas"
                        });
                });

            modelBuilder.Entity("WebSiteWasi.Models.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompra"));

                    b.Property<string>("ContactoCompra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionCompra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacionCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMetodoPago")
                        .HasColumnType("int");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TelefonoCompra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalCompra")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalProductoCompra")
                        .HasColumnType("int");

                    b.HasKey("IdCompra");

                    b.HasIndex("IdMetodoPago");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("WebSiteWasi.Models.DetalleCompra", b =>
                {
                    b.Property<int>("IdDetalleCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleCompra"));

                    b.Property<int>("CantidadDetalleCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalDetalleCompra")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDetalleCompra");

                    b.HasIndex("IdCompra");

                    b.HasIndex("IdProducto");

                    b.ToTable("DetalleCompras");
                });

            modelBuilder.Entity("WebSiteWasi.Models.MetodoPago", b =>
                {
                    b.Property<int>("IdMetodoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMetodoPago"));

                    b.Property<string>("NombreMetodoPago")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMetodoPago");

                    b.ToTable("MetodoPagos");

                    b.HasData(
                        new
                        {
                            IdMetodoPago = 1,
                            NombreMetodoPago = "EFECTIVO"
                        },
                        new
                        {
                            IdMetodoPago = 2,
                            NombreMetodoPago = "TARJETA"
                        });
                });

            modelBuilder.Entity("WebSiteWasi.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("DescripcionProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacionProducto")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("ImagenURLProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioProducto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockProducto")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            IdProducto = 1,
                            DescripcionProducto = "Pantalla AMOLED de 6.2 pulgadas, 128GB",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5054),
                            IdCategoria = 1,
                            ImagenURLProducto = "Smartphone_Galaxy_S21.webp",
                            NombreProducto = "Smartphone Galaxy S21",
                            PrecioProducto = 799.99m,
                            StockProducto = 50
                        },
                        new
                        {
                            IdProducto = 2,
                            DescripcionProducto = "Intel i5, 8GB RAM, 256GB SSD",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5065),
                            IdCategoria = 1,
                            ImagenURLProducto = "Laptop_Dell_Inspiron_15.png",
                            NombreProducto = "Laptop Dell Inspiron 15",
                            PrecioProducto = 699.99m,
                            StockProducto = 40
                        },
                        new
                        {
                            IdProducto = 3,
                            DescripcionProducto = "Pantalla Retina de 10.9 pulgadas, 64GB",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5115),
                            IdCategoria = 1,
                            ImagenURLProducto = "Tablet_iPad_10th_Gen.png",
                            NombreProducto = "Tablet iPad 10th Gen",
                            PrecioProducto = 499.99m,
                            StockProducto = 30
                        },
                        new
                        {
                            IdProducto = 4,
                            DescripcionProducto = "Cancelación de ruido, batería 30 horas",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5117),
                            IdCategoria = 1,
                            ImagenURLProducto = "Audífonos_Bluetooth_Sony_WH_1000XM4.jfif",
                            NombreProducto = "Audífonos Bluetooth Sony WH-1000XM4",
                            PrecioProducto = 349.99m,
                            StockProducto = 60
                        },
                        new
                        {
                            IdProducto = 5,
                            DescripcionProducto = "Resolución 3840 x 2160, HDR10+",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5119),
                            IdCategoria = 1,
                            ImagenURLProducto = "Televisor_Samsung_4K_UHD_50.webp",
                            NombreProducto = "Televisor Samsung 4K UHD 50'' ",
                            PrecioProducto = 599.99m,
                            StockProducto = 25
                        },
                        new
                        {
                            IdProducto = 6,
                            DescripcionProducto = "Transpirable, 100% poliéster, color negro",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5120),
                            IdCategoria = 2,
                            ImagenURLProducto = "Camiseta_Nike_negra.png",
                            NombreProducto = "Camiseta Deportiva Nike ",
                            PrecioProducto = 29.99m,
                            StockProducto = 150
                        },
                        new
                        {
                            IdProducto = 7,
                            DescripcionProducto = "Levis 501 Corte clásico, azul índigo",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5121),
                            IdCategoria = 2,
                            ImagenURLProducto = "Pantalon_Jeans.png",
                            NombreProducto = "Pantalón Jeans ",
                            PrecioProducto = 59.99m,
                            StockProducto = 120
                        },
                        new
                        {
                            IdProducto = 8,
                            DescripcionProducto = "Suela amortiguada, color blanco",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5122),
                            IdCategoria = 2,
                            ImagenURLProducto = "Zapatillas.webp",
                            NombreProducto = "Zapatillas Adidas",
                            PrecioProducto = 99.99m,
                            StockProducto = 30
                        },
                        new
                        {
                            IdProducto = 9,
                            DescripcionProducto = "Material de lana, color gris",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5124),
                            IdCategoria = 2,
                            ImagenURLProducto = "Sombrero_Fedora.webp",
                            NombreProducto = "Sombrero Fedora",
                            PrecioProducto = 19.99m,
                            StockProducto = 70
                        },
                        new
                        {
                            IdProducto = 10,
                            DescripcionProducto = "Suave al tacto, color beige",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5125),
                            IdCategoria = 2,
                            ImagenURLProducto = "BufandaCachemir.webp",
                            NombreProducto = "Bufanda Cachemir",
                            PrecioProducto = 39.99m,
                            StockProducto = 40
                        },
                        new
                        {
                            IdProducto = 11,
                            DescripcionProducto = "Videojuego de acción y aventura hack and slash",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5127),
                            IdCategoria = 3,
                            ImagenURLProducto = "God_of_war_3.png",
                            NombreProducto = "God of War 3",
                            PrecioProducto = 129.99m,
                            StockProducto = 20
                        },
                        new
                        {
                            IdProducto = 12,
                            DescripcionProducto = "Simulación de fútbol publicado por Electronic Arts",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5128),
                            IdCategoria = 3,
                            ImagenURLProducto = "FIFA_23.webp",
                            NombreProducto = "FIFA 23",
                            PrecioProducto = 99.99m,
                            StockProducto = 100
                        },
                        new
                        {
                            IdProducto = 13,
                            DescripcionProducto = "Simulación de carreras de 2022 desarrollado por Polyphony Digital",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5129),
                            IdCategoria = 3,
                            ImagenURLProducto = "Gran_Turismo_7.png",
                            NombreProducto = "GranTurismo 7",
                            PrecioProducto = 89.99m,
                            StockProducto = 125
                        },
                        new
                        {
                            IdProducto = 14,
                            DescripcionProducto = "Consola, 1TB, incluye mando y juegos",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5130),
                            IdCategoria = 3,
                            ImagenURLProducto = "PlayStation_5.png",
                            NombreProducto = "PlayStation 5",
                            PrecioProducto = 599.99m,
                            StockProducto = 100
                        },
                        new
                        {
                            IdProducto = 15,
                            DescripcionProducto = "Consola, 1TB, incluye mando",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5132),
                            IdCategoria = 3,
                            ImagenURLProducto = "Xbox_Series_X.png",
                            NombreProducto = "Xbox Series X",
                            PrecioProducto = 449.99m,
                            StockProducto = 100
                        },
                        new
                        {
                            IdProducto = 16,
                            DescripcionProducto = "Coca Cola Personal Fría",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5133),
                            IdCategoria = 4,
                            ImagenURLProducto = "CocaCola.webp",
                            NombreProducto = "Coca Cola",
                            PrecioProducto = 3.5m,
                            StockProducto = 500
                        },
                        new
                        {
                            IdProducto = 17,
                            DescripcionProducto = "Pepsi 1L Fría",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5135),
                            IdCategoria = 4,
                            ImagenURLProducto = "Pepsi.png",
                            NombreProducto = "Pepsi",
                            PrecioProducto = 8.99m,
                            StockProducto = 600
                        },
                        new
                        {
                            IdProducto = 18,
                            DescripcionProducto = "Agua San Luis Personal Sin Gas",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5136),
                            IdCategoria = 4,
                            ImagenURLProducto = "SAN_LUIS.png",
                            NombreProducto = "Agua San Luis",
                            PrecioProducto = 2.59m,
                            StockProducto = 400
                        },
                        new
                        {
                            IdProducto = 19,
                            DescripcionProducto = "IncaKola Personal Fría",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5137),
                            IdCategoria = 4,
                            ImagenURLProducto = "IncaKola.png",
                            NombreProducto = "IncaKola",
                            PrecioProducto = 3.50m,
                            StockProducto = 500
                        },
                        new
                        {
                            IdProducto = 20,
                            DescripcionProducto = "Corona Extra 500ml",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5138),
                            IdCategoria = 4,
                            ImagenURLProducto = "Corona.webp",
                            NombreProducto = "Corona Extra",
                            PrecioProducto = 16.99m,
                            StockProducto = 100
                        },
                        new
                        {
                            IdProducto = 21,
                            DescripcionProducto = "Galletas de mantequilla en cada de lata",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5140),
                            IdCategoria = 5,
                            ImagenURLProducto = "Galletas_caja_lata.webp",
                            NombreProducto = "Galletas",
                            PrecioProducto = 20.99m,
                            StockProducto = 100
                        },
                        new
                        {
                            IdProducto = 22,
                            DescripcionProducto = "1 Pollo de brasa con papas fritas y ensalada",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5141),
                            IdCategoria = 5,
                            ImagenURLProducto = "Pollo_brasa.png",
                            NombreProducto = "Pollito de brasa",
                            PrecioProducto = 99.99m,
                            StockProducto = 300
                        },
                        new
                        {
                            IdProducto = 23,
                            DescripcionProducto = "Paneton Todinno Caja Grande",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5142),
                            IdCategoria = 5,
                            ImagenURLProducto = "todino.png",
                            NombreProducto = "Paneton Todinno",
                            PrecioProducto = 29.90m,
                            StockProducto = 400
                        },
                        new
                        {
                            IdProducto = 24,
                            DescripcionProducto = "Pavo al horno grande 12kg",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5144),
                            IdCategoria = 5,
                            ImagenURLProducto = "Pavo.png",
                            NombreProducto = "Pavo al horno",
                            PrecioProducto = 129.99m,
                            StockProducto = 50
                        },
                        new
                        {
                            IdProducto = 25,
                            DescripcionProducto = "Ensalada de Verdura fresas y saludables",
                            FechaCreacionProducto = new DateTime(2024, 11, 25, 23, 1, 46, 524, DateTimeKind.Local).AddTicks(5145),
                            IdCategoria = 5,
                            ImagenURLProducto = "Ensalada.png",
                            NombreProducto = "Ensalada de Verduras",
                            PrecioProducto = 19.90m,
                            StockProducto = 120
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebSiteWasi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebSiteWasi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSiteWasi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebSiteWasi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSiteWasi.Models.Carrito", b =>
                {
                    b.HasOne("WebSiteWasi.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Carrito")
                        .HasForeignKey("WebSiteWasi.Models.Carrito", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("WebSiteWasi.Models.CarritoProducto", b =>
                {
                    b.HasOne("WebSiteWasi.Models.Carrito", "Carrito")
                        .WithMany("CarritoProductos")
                        .HasForeignKey("IdCarrito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSiteWasi.Models.Producto", "Producto")
                        .WithMany("CarritoProductos")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebSiteWasi.Models.Compra", b =>
                {
                    b.HasOne("WebSiteWasi.Models.MetodoPago", "MetodoPago")
                        .WithMany("Compras")
                        .HasForeignKey("IdMetodoPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Compra_MetodoPago");

                    b.HasOne("WebSiteWasi.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Compras")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("MetodoPago");
                });

            modelBuilder.Entity("WebSiteWasi.Models.DetalleCompra", b =>
                {
                    b.HasOne("WebSiteWasi.Models.Compra", "Compra")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSiteWasi.Models.Producto", "Producto")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebSiteWasi.Models.Producto", b =>
                {
                    b.HasOne("WebSiteWasi.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Producto_Categoria");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("WebSiteWasi.Models.ApplicationUser", b =>
                {
                    b.Navigation("Carrito")
                        .IsRequired();

                    b.Navigation("Compras");
                });

            modelBuilder.Entity("WebSiteWasi.Models.Carrito", b =>
                {
                    b.Navigation("CarritoProductos");
                });

            modelBuilder.Entity("WebSiteWasi.Models.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("WebSiteWasi.Models.Compra", b =>
                {
                    b.Navigation("DetalleCompras");
                });

            modelBuilder.Entity("WebSiteWasi.Models.MetodoPago", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("WebSiteWasi.Models.Producto", b =>
                {
                    b.Navigation("CarritoProductos");

                    b.Navigation("DetalleCompras");
                });
#pragma warning restore 612, 618
        }
    }
}
