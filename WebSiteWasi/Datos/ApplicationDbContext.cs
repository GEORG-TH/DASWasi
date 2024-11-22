using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Models;

namespace WebSiteWasi.Datos
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuración de la relación entre Producto y Categoria
            builder.Entity<Producto>()
                .HasOne(p => p.Categoria) // Producto tiene una Categoria
                .WithMany(c => c.Productos) // Categoria tiene muchos productos
                .HasForeignKey(p => p.IdCategoria) // La clave foránea en Producto es IdCategoria
                .HasConstraintName("FK_Producto_Categoria"); // Nombre de la restricción de la clave foránea

            // Configuración del tipo de datos para el PrecioProducto
            builder.Entity<Producto>()
                .Property(p => p.PrecioProducto)
                .HasColumnType("decimal(18,2)");

            // (Opcional) Puedes definir convenciones de nombres si deseas personalizar más
            builder.Entity<Categoria>()
                .ToTable("Categorias")
                .Property(c => c.IdCategoria)
                .HasColumnName("IdCategoria");

            builder.Entity<Producto>()
                .ToTable("Productos")
                .Property(p => p.IdProducto)
                .HasColumnName("IdProducto");

            // (Opcional) Si quieres personalizar los nombres de las columnas, puedes usar HasColumnName() también.

            // Crear los roles de identidad (si es necesario)
            var admin = new IdentityRole("ADMIN");
            admin.NormalizedName = "ADMIN";

            var client = new IdentityRole("CLIENT");
            client.NormalizedName = "CLIENT";

            builder.Entity<IdentityRole>().HasData(admin, client);
        }
    }
}
