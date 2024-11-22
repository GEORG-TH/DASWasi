using System.ComponentModel.DataAnnotations;

namespace WebSiteWasi.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de la categoría no puede superar los 50 caracteres.")]
        public string NombreCategoria { get; set; }

        public ICollection<Producto>? Productos { get; set; }

    }
}
