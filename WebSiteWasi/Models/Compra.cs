using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebSiteWasi.Models
{
    public class Compra
    {

        [Key]
        public int IdCompra { get; set; }

        public int TotalProductoCompra { get; set; }

        public decimal TotalCompra {  get; set; }

        public string ContactoCompra { get; set; }

        public string TelefonoCompra { get; set; }

        public string DireccionCompra { get; set; }

        public DateTime FechaCreacionCompra { get; set; }



        public int IdMetodoPago { get; set; }

        public MetodoPago MetodoPago { get; set; }



        public string IdUsuario { get; set; }

        public ApplicationUser ApplicationUser { get; set; }



        public ICollection<DetalleCompra>? DetalleCompras { get; set; }

    }
}
