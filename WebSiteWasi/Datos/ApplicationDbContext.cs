using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Models;

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
    }



}
