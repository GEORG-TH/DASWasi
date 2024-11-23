using System.ComponentModel.DataAnnotations;

namespace WebSiteWasi.Models
{
    public class MetodoPago
    {
        [Key]
        public int IdMetodoPago { get; set; }

        [Required(ErrorMessage = "El nombre del MetodoPago es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del MetodoPago no puede superar los 50 caracteres.")]
        public string? NombreMetodoPago { get; set; }

        public MetodoPago(int idMetodoPago, string nombreMetodoPago)
        {
            IdMetodoPago = idMetodoPago;
            NombreMetodoPago = nombreMetodoPago;
        }

        public ICollection<Compra>? Compras { get; set; }
    }
}
