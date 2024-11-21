using System.ComponentModel.DataAnnotations;

namespace WebSiteWasi.Models
{
    public class Producto
    {

        [Key]
        public int IdProducto { get; set; }

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
        public string IdCategoria { get; set; }

        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Debe subir una imagen.")]
        public string ImagenURLProducto { get; set; } 
    }
}
