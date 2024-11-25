using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Models;

namespace WebSiteWasi.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment environment;



        public ProductoController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            this.environment = environment; 
        }

        [Authorize(Roles = "ADMIN,CLIENT")]
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


        public IActionResult RegistrarProducto(ProductoDto productoDto)
        {
            
            if (productoDto.ImagenFile == null || productoDto.ImagenFile.Length == 0)
            {
                ModelState.AddModelError("ImagenFile", "Debe subir una imagen para el producto.");
            }

            
            if (productoDto.ImagenFile != null && !productoDto.ImagenFile.ContentType.StartsWith("image"))
            {
                ModelState.AddModelError("ImagenFile", "El archivo debe ser una imagen válida.");
            }

            if (ModelState.IsValid)
            {

                string newImageFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newImageFileName += Path.GetExtension(productoDto.ImagenFile!.FileName);

                string imagenFileFullPath = environment.WebRootPath + "/ImagenesProductos/" + newImageFileName;

                using(var stream = System.IO.File.Create(imagenFileFullPath))
                {
                    productoDto.ImagenFile.CopyTo(stream);
                }

                Producto producto = new Producto();

                producto.NombreProducto = productoDto.NombreProducto;
                producto.DescripcionProducto = productoDto.DescripcionProducto;
                producto.PrecioProducto = productoDto.PrecioProducto;
                producto.StockProducto = productoDto.StockProducto;
                producto.IdCategoria = productoDto.IdCategoria;
                producto.ImagenURLProducto = newImageFileName;
                producto.FechaCreacionProducto = DateTime.Now;

                _db.Productos.Add(producto);
                _db.SaveChanges();
                return RedirectToAction(nameof(VistaListaProductos));
            }

            var categorias = _db.Categorias
                .Select(c => new SelectListItem
                {
                    Value = c.IdCategoria.ToString(),
                    Text = c.NombreCategoria
                }).ToList();


            ViewData["Categorias"] = categorias;

            return View(productoDto); 
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

            ProductoDto productoDto = new ProductoDto();
            productoDto.NombreProducto = obj.NombreProducto;
            productoDto.DescripcionProducto = obj.DescripcionProducto;
            productoDto.PrecioProducto = obj.PrecioProducto;
            productoDto.StockProducto = obj.StockProducto;
            productoDto.IdCategoria = obj.IdCategoria;


            ViewData["ImagenURLProducto"] = obj.ImagenURLProducto;

            var categorias = _db.Categorias
                .Select(c => new SelectListItem
                {
                    Value = c.IdCategoria.ToString(),
                    Text = c.NombreCategoria
                }).ToList();


            ViewData["Categorias"] = categorias;
            ViewData["IdProducto"] = obj.IdProducto;




            return View(productoDto);
        }



        [HttpPost]
        public IActionResult ModificarProducto(int IdProducto, ProductoDto productoDto)
        {
            if (IdProducto == null || IdProducto == 0)
            {
                return NotFound();
            }
            var obj = _db.Productos.Find(IdProducto);

            if (obj == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                string newImageFileName = obj.ImagenURLProducto;

                if (productoDto.ImagenFile !=null)
                {

                    newImageFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    newImageFileName += Path.GetExtension(productoDto.ImagenFile!.FileName);

                    string imagenFileFullPath = environment.WebRootPath + "/ImagenesProductos/" + newImageFileName;

                    using (var stream = System.IO.File.Create(imagenFileFullPath))
                    {
                        productoDto.ImagenFile.CopyTo(stream);
                    }

                    string oldImagenFileFullPath = environment.WebRootPath + "/ImagenesProductos/" + obj.ImagenURLProducto;
                    System.IO.File.Delete(oldImagenFileFullPath);

                }

                obj.NombreProducto = productoDto.NombreProducto;
                obj.DescripcionProducto = productoDto.DescripcionProducto;
                obj.PrecioProducto = productoDto.PrecioProducto;
                obj.StockProducto = productoDto.StockProducto;
                obj.IdCategoria = productoDto.IdCategoria;
                obj.ImagenURLProducto = newImageFileName;


                _db.Productos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(VistaListaProductos));
            }

            ViewData["ImagenURLProducto"] = obj.ImagenURLProducto;

            var categorias = _db.Categorias
                .Select(c => new SelectListItem
                {
                    Value = c.IdCategoria.ToString(),
                    Text = c.NombreCategoria
                }).ToList();


            ViewData["Categorias"] = categorias;
            ViewData["IdProducto"] = obj.IdProducto;


            return View(productoDto);
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

            ProductoDto productoDto = new ProductoDto();
            productoDto.NombreProducto = obj.NombreProducto;
            productoDto.DescripcionProducto = obj.DescripcionProducto;
            productoDto.PrecioProducto = obj.PrecioProducto;
            productoDto.StockProducto = obj.StockProducto;
            productoDto.IdCategoria = obj.IdCategoria;


            ViewData["ImagenURLProducto"] = obj.ImagenURLProducto;

            var categorias = _db.Categorias
                .Select(c => new SelectListItem
                {
                    Value = c.IdCategoria.ToString(),
                    Text = c.NombreCategoria
                }).ToList();


            ViewData["Categorias"] = categorias;
            ViewData["IdProducto"] = obj.IdProducto;


            return View(productoDto);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarProducto(int IdProducto, ProductoDto productoDto)
        {
            if (IdProducto == null || IdProducto == 0)
            {
                return NotFound();
            }
            var obj = _db.Productos.Find(IdProducto);

            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                string imagenFileFullPath = environment.WebRootPath + "/ImagenesProductos/" + obj.ImagenURLProducto;
                System.IO.File.Delete(imagenFileFullPath);

                _db.Productos.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(VistaListaProductos));
            }
            
        }


        // Acción para mostrar los detalles del producto
        public async Task<IActionResult> Detalles(int id)
        {
            // Buscar el producto por su Id
            var producto = await _db.Productos
                .FirstOrDefaultAsync(p => p.IdProducto == id);

            // Verificar si el producto existe
            if (producto == null)
            {
                return NotFound();  // Si no se encuentra el producto, retorna un error 404
            }

            // Devolver la vista con el producto
            return View(producto);
        }

    }

}
