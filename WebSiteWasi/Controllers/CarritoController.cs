using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Models;

namespace WebSiteWasi.Controllers
{
    public class CarritoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CarritoController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // Acción para ver el carrito
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User); // Obtener el usuario autenticado
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var carrito = await _context.Carritos
                .Where(c => c.IdUsuario == user.Id)
                .Include(c => c.CarritoProductos)
                .ThenInclude(cp => cp.Producto)
                .FirstOrDefaultAsync();

            // Si no tiene un carrito, crear uno vacío
            if (carrito == null)
            {
                carrito = new Carrito { IdUsuario = user.Id };
                _context.Carritos.Add(carrito);
                await _context.SaveChangesAsync();
            }

            // Calcular el número total de productos en el carrito (solo productos únicos)
            ViewData["CartItemCount"] = carrito.CarritoProductos?.Count() ?? 0;

            return View(carrito);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAlCarrito(int productoId, int cantidad)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var producto = await _context.Productos.FindAsync(productoId);
            if (producto == null || cantidad <= 0)
            {
                return RedirectToAction("Index", "Producto");
            }

            var carrito = await _context.Carritos
                .Where(c => c.IdUsuario == user.Id)
                .Include(c => c.CarritoProductos)
                .FirstOrDefaultAsync();

            if (carrito == null)
            {
                carrito = new Carrito { IdUsuario = user.Id };
                _context.Carritos.Add(carrito);
                await _context.SaveChangesAsync();
            }

            var carritoProducto = carrito.CarritoProductos.FirstOrDefault(cp => cp.IdProducto == productoId);

            if (carritoProducto != null)
            {
                carritoProducto.Cantidad += cantidad; // Si ya está en el carrito, solo actualizamos la cantidad
            }
            else
            {
                carrito.CarritoProductos.Add(new CarritoProducto
                {
                    Producto = producto,
                    Cantidad = cantidad
                });
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }








        // Acción para actualizar la cantidad de un producto en el carrito
        [HttpPost]
        public async Task<IActionResult> ActualizarCantidad(int idCarritoProducto, int cantidad)
        {
            var user = await _userManager.GetUserAsync(User); // Obtener el usuario autenticado
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var carritoProducto = await _context.CarritoProductos
                .FirstOrDefaultAsync(cp => cp.IdCarritoProducto == idCarritoProducto && cp.Carrito.IdUsuario == user.Id);

            if (carritoProducto != null)
            {
                // Actualizar la cantidad en la base de datos
                carritoProducto.Cantidad = cantidad;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Carrito");
        }

        // Acción para eliminar un producto del carrito
        public async Task<IActionResult> EliminarDelCarrito(int id)
        {
            var user = await _userManager.GetUserAsync(User); // Obtener el usuario autenticado
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var carritoProducto = await _context.CarritoProductos
                .FirstOrDefaultAsync(cp => cp.IdCarritoProducto == id && cp.Carrito.IdUsuario == user.Id);

            if (carritoProducto != null)
            {
                // Eliminar el producto del carrito
                _context.CarritoProductos.Remove(carritoProducto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Carrito");
        }





    }
}
