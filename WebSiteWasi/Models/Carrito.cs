using System.ComponentModel.DataAnnotations;

namespace WebSiteWasi.Models
{
    public class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }

        public DateTime FechaCreacionCarrito { get; set; }




        public string IdUsuario { get; set; }

        public ApplicationUser ApplicationUser { get; set; }



        public ICollection<CarritoProducto>? CarritoProductos { get; set; }



        

    }
}
