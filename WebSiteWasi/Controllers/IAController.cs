using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSiteWasi.Services;

namespace WebSiteWasi.Controllers
{
    public class IAController : Controller
    {
        private readonly GeminiRecommendationService _geminiRecommendationService;

        public IAController(GeminiRecommendationService geminiRecommendationService)
        {
            _geminiRecommendationService = geminiRecommendationService;
        }

        public async Task<IActionResult> RecommendProducto(string productname)
        {
            if (string.IsNullOrEmpty(productname))
            {
                ViewBag.Error = "Por favor, ingresa la ocacasion.";
                return View("Index");
            }

            // Obtener recomendaciones utilizando Gemini
            var recommendations = await _geminiRecommendationService.GetProductRecommendationsAsync(productname);

            // Pasar las recomendaciones a la vista
            ViewBag.Recommendations = recommendations;
            ViewBag.ProductName = productname; // Para mostrar el nombre del producto en la vista

            return View("RecommendProducto");
        }
    }

}
