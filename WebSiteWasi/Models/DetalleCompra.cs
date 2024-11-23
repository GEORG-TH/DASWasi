using System.ComponentModel.DataAnnotations;

namespace WebSiteWasi.Models
{
    public class DetalleCompra
    {

        [Key]
        public int IdDetalleCompra { get; set; }

        public int CantidadDetalleCompra { get; set; }

        public decimal TotalDetalleCompra { get; set; }



        public int IdCompra { get; set; }

        public Compra Compra { get; set; }



        public int IdProducto { get; set; }

        public Producto Producto { get; set; }


    }
}
