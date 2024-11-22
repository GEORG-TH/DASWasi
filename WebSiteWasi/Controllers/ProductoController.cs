using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }


        public IActionResult RegistrarProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _db.Productos.Add(producto);
                _db.SaveChanges();
                return RedirectToAction(nameof(VistaListaProductos));
            }
            return View(producto);
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
