using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Datos;
using WebSiteWasi.Models;

namespace WebSiteWasi.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult VistaListaCategorias()
        {
            IEnumerable<Categoria> lista = _db.Categorias;
            return View(lista);
        }


        [Authorize(Roles = "ADMIN")]
        public IActionResult VistaRegistrarCategoria()
        {
            return View();
        }

        
        public IActionResult RegistrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categorias.Add(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(VistaListaCategorias));
            }
            return View(categoria);
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult VistaModificarCategoria(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categorias.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categorias.Update(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(VistaListaCategorias));
            }
            return View(categoria);
        }


        [Authorize(Roles = "ADMIN")]
        public IActionResult VistaPreEliminarCategoria(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categorias.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarCategoria(Categoria categoria)
        {
            if (categoria == null)
            {
                return NotFound();
            }
            _db.Categorias.Remove(categoria);
            _db.SaveChanges();
            return RedirectToAction(nameof(VistaListaCategorias));
        }




        public async Task<IActionResult> VistaListaProductosPorCategoria(int id)
        {
            // Obtener todos los productos de la categoría con el id proporcionado
            var productos = await _db.Productos
                                          .Where(p => p.IdCategoria == id) // Filtramos por IdCategoria
                                          .Include(p => p.Categoria)  // Incluir la categoría asociada a cada producto
                                          .ToListAsync();

            // Verifica si hay productos para la categoría
            if (productos == null)
            {
                return NotFound();  // Si no se encuentra la categoría o no hay productos, retorna un error 404
            }

            // Retorna la vista con la lista de productos filtrados por la categoría seleccionada
            return View(productos);
        }





    }
}
