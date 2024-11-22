using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteWasi.Models
{
    public class Producto
    {

        [Key]
        public int IdProducto { get; set; }

        public string NombreProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public decimal PrecioProducto { get; set; }

        public int IdCategoria { get; set; }

        public string ImagenURLProducto { get; set; } 

        public DateTime FechaCreacionProducto { get; set; }
    }
}
