using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Models;

namespace WebSiteWasi.Controllers
{
    public class CompraController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CompraController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: ConfirmarCompra
        public async Task<IActionResult> ConfirmarCompra()
        {
            // Obtener el usuario actual
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Obtener el carrito del usuario
            var carrito = await _context.Carritos
                .Where(c => c.IdUsuario == user.Id)
                .Include(c => c.CarritoProductos)
                .ThenInclude(cp => cp.Producto)
                .FirstOrDefaultAsync();

            if (carrito == null || carrito.CarritoProductos.Count == 0)
            {
                return RedirectToAction("Index", "Producto"); // Redirigir si no hay productos en el carrito
            }

            // Obtener los métodos de pago disponibles
            var metodosPago = await _context.MetodoPagos
                .Select(mp => new SelectListItem
                {
                    Value = mp.IdMetodoPago.ToString(),
                    Text = mp.NombreMetodoPago
                }).ToListAsync();

            // Preparar los datos para la vista
            ViewData["ContactoCompra"] = $"{user.Nombre} {user.Apellido}";
            ViewData["TelefonoCompra"] = user.PhoneNumber;
            ViewData["DireccionCompra"] = user.Direccion;
            ViewData["MetodosPago"] = metodosPago;
            ViewData["TotalCompra"] = carrito.CarritoProductos.Sum(cp => cp.Producto.PrecioProducto * cp.Cantidad);

            return View();
        }












        // POST: ConfirmarCompra
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarCompra(string contactoCompra, string telefonoCompra, string direccionCompra, int idMetodoPago)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Obtener el carrito del usuario
            var carrito = await _context.Carritos
                .Where(c => c.IdUsuario == user.Id)
                .Include(c => c.CarritoProductos)
                .ThenInclude(cp => cp.Producto)
                .FirstOrDefaultAsync();

            if (carrito == null || carrito.CarritoProductos.Count == 0)
            {
                return RedirectToAction("Index", "Producto"); // Redirigir si no hay productos en el carrito
            }

            // Calcular el total de productos y el total de la compra
            var totalProductosCompra = carrito.CarritoProductos.Sum(cp => cp.Cantidad);
            var totalCompra = carrito.CarritoProductos.Sum(cp => cp.Producto.PrecioProducto * cp.Cantidad);

            // Crear una nueva compra
            var compra = new Compra
            {
                TotalProductoCompra = totalProductosCompra,  // Guardamos la cantidad total de productos comprados
                TotalCompra = totalCompra,
                ContactoCompra = contactoCompra,
                TelefonoCompra = telefonoCompra,
                DireccionCompra = direccionCompra,
                FechaCreacionCompra = DateTime.Now,
                IdMetodoPago = idMetodoPago,
                IdUsuario = user.Id
            };

            // Iniciar una transacción para garantizar la integridad de los datos
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Guardar la compra y obtener el IdCompra generado
                    _context.Compras.Add(compra);
                    await _context.SaveChangesAsync();  // Guardamos la compra aquí

                    // Asegurarse de que el IdCompra esté asignado
                    var idCompraGenerado = compra.IdCompra;

                    // Ahora que tenemos el IdCompra, podemos agregar los detalles de la compra
                    foreach (var item in carrito.CarritoProductos)
                    {
                        // Verificar si el producto existe en la base de datos
                        var producto = await _context.Productos
                            .FirstOrDefaultAsync(p => p.IdProducto == item.Producto.IdProducto);
                        if (producto == null)
                        {
                            throw new Exception($"El producto con ID {item.Producto.IdProducto} no existe.");
                        }

                        var detalleCompra = new DetalleCompra
                        {
                            CantidadDetalleCompra = item.Cantidad,
                            TotalDetalleCompra = producto.PrecioProducto * item.Cantidad,
                            IdCompra = idCompraGenerado,  // Asociamos el IdCompra
                            IdProducto = item.Producto.IdProducto  // Asociamos el IdProducto
                        };

                        _context.DetalleCompras.Add(detalleCompra);

                        // Actualizar el stock del producto
                        producto.StockProducto -= item.Cantidad;
                        _context.Productos.Update(producto);  // Guardar la actualización del stock
                    }

                    // Guardar los detalles de la compra y la actualización de los productos
                    await _context.SaveChangesAsync();

                    // Eliminar los productos del carrito (una vez realizada la compra)
                    _context.CarritoProductos.RemoveRange(carrito.CarritoProductos);
                    await _context.SaveChangesAsync();

                    // Commit de la transacción
                    await transaction.CommitAsync();

                    // Redirigir a la página de éxito de compra
                    return RedirectToAction("CompraExitosa");
                }
                catch (Exception ex)
                {
                    // Si ocurre algún error, se realiza un rollback
                    await transaction.RollbackAsync();
                    // Registrar el error
                    ModelState.AddModelError("", $"Ocurrió un error al procesar la compra: {ex.Message}");
                    return View();
                }
            }
        }




        // GET: CompraExitosa
        public IActionResult CompraExitosa()
        {
            return View();
        }
    }
}