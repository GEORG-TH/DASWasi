using Microsoft.AspNetCore.Identity;

namespace WebSiteWasi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; } = "";

        public string Apellido { get; set; } = "";

        public string Direccion { get; set; } = "";

        public DateTime FechaCreacion { get; set; }
    }
}
