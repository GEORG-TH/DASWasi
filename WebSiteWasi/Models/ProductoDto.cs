using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebSiteWasi.Models
{
    public class ProductoDto
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del producto no puede superar los 50 caracteres.")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "La descripcion del producto es obligatorio.")]
        [StringLength(50, ErrorMessage = "La descripcion del producto no puede superar los 50 caracteres.")]
        public string DescripcionProducto { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [Range(1, 10000, ErrorMessage = "El precio debe estar entre 1 y 10 000.")]
        public decimal PrecioProducto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        public int IdCategoria { get; set; }

        public IFormFile? ImagenFile { get; set; }
    }
}
