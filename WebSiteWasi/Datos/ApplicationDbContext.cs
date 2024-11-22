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

            var admin = new IdentityRole("ADMIN");

            admin.NormalizedName = "ADMIN";

            var client = new IdentityRole("CLIENT");

            client.NormalizedName = "CLIENT";

            builder.Entity<IdentityRole>().HasData(admin,client);
        }
    }
}
