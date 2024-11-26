using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Models;
using System.Reflection.Emit;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<MetodoPago> MetodoPagos { get; set; }
    public DbSet<DetalleCompra> DetalleCompras { get; set; }
    public DbSet<Carrito> Carritos { get; set; }
    public DbSet<CarritoProducto> CarritoProductos { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {


        base.OnModelCreating(builder);

        // Relación entre Compra y MetodoPago
        builder.Entity<Compra>()
            .HasOne(c => c.MetodoPago)
            .WithMany(m => m.Compras)
            .HasForeignKey(c => c.IdMetodoPago)
            .HasConstraintName("FK_Compra_MetodoPago");



        // Relación entre Producto y Categoria
        builder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.IdCategoria)
            .HasConstraintName("FK_Producto_Categoria");



        // Relación entre Compra y ApplicationUser
        builder.Entity<Compra>()
            .HasOne(c => c.ApplicationUser)
            .WithMany(u => u.Compras)
            .HasForeignKey(c => c.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);




        // Relación entre Carrito y ApplicationUser
        builder.Entity<ApplicationUser>()
            .HasOne(u => u.Carrito)  // Un usuario tiene un solo carrito
            .WithOne(c => c.ApplicationUser)  // Un carrito pertenece a un solo usuario
            .HasForeignKey<Carrito>(c => c.IdUsuario)  // La clave foránea en Carrito es IdUsuario
            .OnDelete(DeleteBehavior.Cascade);  // Cuando se elimina el usuario, también se elimina el carrito




        // Relación entre Carrito y CarritoProducto
        builder.Entity<CarritoProducto>()
            .HasOne(cp => cp.Carrito)
            .WithMany(c => c.CarritoProductos)
            .HasForeignKey(cp => cp.IdCarrito)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CarritoProducto>()
            .HasOne(cp => cp.Producto)
            .WithMany(p => p.CarritoProductos)
            .HasForeignKey(cp => cp.IdProducto)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<DetalleCompra>()
            .HasOne(d => d.Producto)
            .WithMany(p => p.DetalleCompras)
            .HasForeignKey(d => d.IdProducto)
            .OnDelete(DeleteBehavior.Restrict);  // Asegúrate de que no se eliminen productos al eliminar detalles de compra

        builder.Entity<DetalleCompra>()
    .HasOne(d => d.Compra)
    .WithMany(c => c.DetalleCompras)
    .HasForeignKey(d => d.IdCompra)
    .OnDelete(DeleteBehavior.Cascade);  // Cuando se elimina la compra, se eliminan los detalles de la compra





        // Configuración de los tipos de datos
        builder.Entity<Producto>()
            .Property(p => p.PrecioProducto)
            .HasColumnType("decimal(18,2)");

        builder.Entity<DetalleCompra>()
            .Property(c => c.TotalDetalleCompra)
            .HasColumnType("decimal(18,2)");

        builder.Entity<Compra>()
            .Property(c => c.TotalCompra)
            .HasColumnType("decimal(18,2)");

        // Crear los roles de identidad
        var admin = new IdentityRole("ADMIN");
        admin.NormalizedName = "ADMIN";

        var client = new IdentityRole("CLIENT");
        client.NormalizedName = "CLIENT";

        builder.Entity<IdentityRole>().HasData(admin, client);

        // Crear los métodos de pago (Por defecto)
        var efectivo = new MetodoPago(1, "EFECTIVO");
        var tarjeta = new MetodoPago(2, "TARJETA");

        builder.Entity<MetodoPago>().HasData(efectivo, tarjeta);


        // Crear categorías
        var c1 = new Categoria { IdCategoria = 1, NombreCategoria = "Electrónica" };
        var c2 = new Categoria { IdCategoria = 2, NombreCategoria = "Ropa y Moda" };
        var c3 = new Categoria { IdCategoria = 3, NombreCategoria = "Videojuegos" };
        var c4 = new Categoria { IdCategoria = 4, NombreCategoria = "Comidas" };
        var c5 = new Categoria { IdCategoria = 5, NombreCategoria = "Bebidas" };



        builder.Entity<Categoria>().HasData(c1,c2,c3,c4,c5);


        // Crear productos 
        int IdCategoria = 1;

        var p1 = new Producto
        {
            IdProducto = 1,
            NombreProducto = "Smartphone Galaxy S21",
            DescripcionProducto = "Pantalla AMOLED de 6.2 pulgadas, 128GB",
            PrecioProducto = 799.99m,
            StockProducto = 50,
            ImagenURLProducto = "Smartphone_Galaxy_S21.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p2 = new Producto
        {
            IdProducto = 2,
            NombreProducto = "Laptop Dell Inspiron 15",
            DescripcionProducto = "Intel i5, 8GB RAM, 256GB SSD",
            PrecioProducto = 699.99m,
            StockProducto = 40,
            ImagenURLProducto = "Laptop_Dell_Inspiron_15.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p3 = new Producto
        {
            IdProducto = 3,
            NombreProducto = "Tablet iPad 10th Gen",
            DescripcionProducto = "Pantalla Retina de 10.9 pulgadas, 64GB",
            PrecioProducto = 499.99m,
            StockProducto = 30,
            ImagenURLProducto = "Tablet_iPad_10th_Gen.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p4 = new Producto
        {
            IdProducto = 4,
            NombreProducto = "Audífonos Bluetooth Sony WH-1000XM4",
            DescripcionProducto = "Cancelación de ruido, batería 30 horas",
            PrecioProducto = 349.99m,
            StockProducto = 60,
            ImagenURLProducto = "Audífonos_Bluetooth_Sony_WH_1000XM4.jfif",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p5 = new Producto
        {
            IdProducto = 5,
            NombreProducto = "Televisor Samsung 4K UHD 50'' ",
            DescripcionProducto = "Resolución 3840 x 2160, HDR10+",
            PrecioProducto = 599.99m,
            StockProducto = 25,
            ImagenURLProducto = "Televisor_Samsung_4K_UHD_50.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        IdCategoria = 2;

        var p6 = new Producto
        {
            IdProducto = 6,
            NombreProducto = "Camiseta Deportiva Nike ",
            DescripcionProducto = "Transpirable, 100% poliéster, color negro",
            PrecioProducto = 29.99m,
            StockProducto = 150,
            ImagenURLProducto = "Camiseta_Nike_negra.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p7 = new Producto
        {
            IdProducto = 7,
            NombreProducto = "Pantalón Jeans ",
            DescripcionProducto = "Levis 501 Corte clásico, azul índigo",
            PrecioProducto = 59.99m,
            StockProducto = 120,
            ImagenURLProducto = "Pantalon_Jeans.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p8 = new Producto
        {
            IdProducto = 8,
            NombreProducto = "Zapatillas Adidas",
            DescripcionProducto = "Suela amortiguada, color blanco",
            PrecioProducto = 99.99m,
            StockProducto = 30,
            ImagenURLProducto = "Zapatillas.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p9 = new Producto
        {
            IdProducto = 9,
            NombreProducto = "Sombrero Fedora",
            DescripcionProducto = "Material de lana, color gris",
            PrecioProducto = 19.99m,
            StockProducto = 70,
            ImagenURLProducto = "Sombrero_Fedora.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p10 = new Producto
        {
            IdProducto = 10,
            NombreProducto = "Bufanda Cachemir",
            DescripcionProducto = "Suave al tacto, color beige",
            PrecioProducto = 39.99m,
            StockProducto = 40,
            ImagenURLProducto = "BufandaCachemir.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        IdCategoria = 3;

        var p11 = new Producto
        {
            IdProducto = 11,
            NombreProducto = "God of War 3",
            DescripcionProducto = "Videojuego de acción y aventura hack and slash",
            PrecioProducto = 129.99m,
            StockProducto = 20,
            ImagenURLProducto = "God_of_war_3.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p12 = new Producto
        {
            IdProducto = 12,
            NombreProducto = "FIFA 23",
            DescripcionProducto = "Simulación de fútbol publicado por Electronic Arts",
            PrecioProducto = 99.99m,
            StockProducto = 100,
            ImagenURLProducto = "FIFA_23.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p13 = new Producto
        {
            IdProducto = 13,
            NombreProducto = "GranTurismo 7",
            DescripcionProducto = "Simulación de carreras de 2022 desarrollado por Polyphony Digital",
            PrecioProducto = 89.99m,
            StockProducto = 125,
            ImagenURLProducto = "Gran_Turismo_7.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p14 = new Producto
        {
            IdProducto = 14,
            NombreProducto = "PlayStation 5",
            DescripcionProducto = "Consola, 1TB, incluye mando y juegos",
            PrecioProducto = 599.99m,
            StockProducto = 100,
            ImagenURLProducto = "PlayStation_5.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p15 = new Producto
        {
            IdProducto = 15,
            NombreProducto = "Xbox Series X",
            DescripcionProducto = "Consola, 1TB, incluye mando",
            PrecioProducto = 449.99m,
            StockProducto = 100,
            ImagenURLProducto = "Xbox_Series_X.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        IdCategoria = 4;

        var p16 = new Producto
        {
            IdProducto = 16,
            NombreProducto = "Coca Cola",
            DescripcionProducto = "Coca Cola Personal Fría",
            PrecioProducto = 3.5m,
            StockProducto = 500,
            ImagenURLProducto = "CocaCola.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p17 = new Producto
        {
            IdProducto = 17,
            NombreProducto = "Pepsi",
            DescripcionProducto = "Pepsi 1L Fría",
            PrecioProducto = 8.99m,
            StockProducto = 600,
            ImagenURLProducto = "Pepsi.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p18 = new Producto
        {
            IdProducto = 18,
            NombreProducto = "Agua San Luis",
            DescripcionProducto = "Agua San Luis Personal Sin Gas",
            PrecioProducto = 2.59m,
            StockProducto = 400,
            ImagenURLProducto = "SAN_LUIS.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p19 = new Producto
        {
            IdProducto = 19,
            NombreProducto = "IncaKola",
            DescripcionProducto = "IncaKola Personal Fría",
            PrecioProducto = 3.50m,
            StockProducto = 500,
            ImagenURLProducto = "IncaKola.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p20 = new Producto
        {
            IdProducto = 20,
            NombreProducto = "Corona Extra",
            DescripcionProducto = "Corona Extra 500ml",
            PrecioProducto = 16.99m,
            StockProducto = 100,
            ImagenURLProducto = "Corona.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        IdCategoria = 5;

        var p21 = new Producto
        {
            IdProducto = 21,
            NombreProducto = "Galletas",
            DescripcionProducto = "Galletas de mantequilla en cada de lata",
            PrecioProducto = 20.99m,
            StockProducto = 100,
            ImagenURLProducto = "Galletas_caja_lata.webp",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p22 = new Producto
        {
            IdProducto = 22,
            NombreProducto = "Pollito de brasa",
            DescripcionProducto = "1 Pollo de brasa con papas fritas y ensalada",
            PrecioProducto = 99.99m,
            StockProducto = 300,
            ImagenURLProducto = "Pollo_brasa.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p23 = new Producto
        {
            IdProducto = 23,
            NombreProducto = "Paneton Todinno",
            DescripcionProducto = "Paneton Todinno Caja Grande",
            PrecioProducto = 29.90m,
            StockProducto = 400,
            ImagenURLProducto = "todino.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p24 = new Producto
        {
            IdProducto = 24,
            NombreProducto = "Pavo al horno",
            DescripcionProducto = "Pavo al horno grande 12kg",
            PrecioProducto = 129.99m,
            StockProducto = 50,
            ImagenURLProducto = "Pavo.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };

        var p25 = new Producto
        {
            IdProducto = 25,
            NombreProducto = "Ensalada de Verduras",
            DescripcionProducto = "Ensalada de Verdura fresas y saludables",
            PrecioProducto = 19.90m,
            StockProducto = 120,
            ImagenURLProducto = "Ensalada.png",
            FechaCreacionProducto = DateTime.Now,
            IdCategoria = IdCategoria
        };


        builder.Entity<Producto>().HasData(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25);
    }



}
