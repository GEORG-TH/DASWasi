using System.ComponentModel.DataAnnotations;

namespace WebSiteWasi.Models
{
    public class CarritoProducto
    {
        [Key]
        public int IdCarritoProducto { get; set; }

        public int Cantidad { get; set; }


        public int IdCarrito {  get; set; }

        public Carrito Carrito { get; set; }


        public int IdProducto { get; set; }

        public Producto Producto { get; set; }

        
    }
}
