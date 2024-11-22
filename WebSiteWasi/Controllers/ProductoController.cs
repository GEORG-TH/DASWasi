using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Datos;
using WebSiteWasi.Models;

namespace WebSiteWasi.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ProductoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult VistaListaProductos()
        {
            IEnumerable<Producto> lista = _db.Productos;
            return View(lista);
        }


        [Authorize(Roles = "ADMIN")]
        public IActionResult VistaRegistrarProducto()
        {

            var categorias = _db.Categorias
                .Select(c => new SelectListItem
                {
                    Value = c.IdCategoria.ToString(),
                    Text = c.NombreCategoria
                }).ToList();


            ViewData["Categorias"] = categorias;
            return View();
        }

        [HttpPost]
public IActionResult RegistrarProducto(Producto producto, IFormFile Imagen)
{
    // Validar si se subió una imagen
    if (Imagen == null || Imagen.Length == 0)
    {
        ModelState.AddModelError("Imagen", "Debe subir una imagen para el producto.");
    }

    // Validar el tipo de archivo (opcional)
    if (Imagen != null && !Imagen.ContentType.StartsWith("image"))
    {
        ModelState.AddModelError("Imagen", "El archivo debe ser una imagen válida.");
    }

    if (ModelState.IsValid)
    {
        // Guardar la imagen en wwwroot/ImagenesProductos si es válida
        if (Imagen != null && Imagen.Length > 0)
        {
            // Generar un nombre único para la imagen
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Imagen.FileName);

            // Ruta completa donde se guardará la imagen
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagenesProductos", fileName);

            // Crear la carpeta si no existe
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }

            // Guardar el archivo en la ruta especificada
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                Imagen.CopyTo(stream);
            }

            // Guardar la ruta relativa de la imagen en el modelo
            producto.ImagenURLProducto = "/ImagenesProductos/" + fileName;
        }

        // Guardar el producto en la base de datos
        producto.FechaCreacionProducto = DateTime.Now;
        _db.Productos.Add(producto);
        _db.SaveChanges();

        return RedirectToAction(nameof(VistaListaProductos));
    }

    // Si hay errores de validación, volver a cargar las categorías para el combo box
    ViewData["Categorias"] = new SelectList(_db.Categorias, "CategoriaId", "NombreCategoria", producto.IdCategoria);

    return View(producto); // Devuelve la vista con los errores
}



        [Authorize(Roles = "ADMIN")]
        public IActionResult VistaModificarProducto(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Productos.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _db.Productos.Update(producto);
                _db.SaveChanges();
                return RedirectToAction(nameof(VistaListaProductos));
            }
            return View(producto);
        }


        [Authorize(Roles = "ADMIN")]
        public IActionResult VistaPreEliminarProducto(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Productos.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarProducto(Producto producto)
        {
            if (producto == null)
            {
                return NotFound();
            }
            _db.Productos.Remove(producto);
            _db.SaveChanges();
            return RedirectToAction(nameof(VistaListaProductos));
        }

    }
}
