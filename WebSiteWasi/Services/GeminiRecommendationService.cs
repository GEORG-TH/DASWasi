using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSiteWasi.Services;

namespace WebSiteWasi.Services
{
    public class GeminiRecommendationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _geminiApiKey;
        private readonly string _geminiApiUrl;

        public GeminiRecommendationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _geminiApiKey = configuration["GeminiApiKey"];
            _geminiApiUrl = configuration["GeminiApiUrl"];
        }

        public async Task<string> GetProductRecommendationsAsync(string productName)
        {
            var url = $"{_geminiApiUrl}?key={_geminiApiKey}";

            // Cambiamos el contenido para hacer que la IA entienda que quieres recomendaciones de productos
            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text = $"Por favor, recomienda solo productos para comprar de un minimarket para la ocasión de: '{productName}'. No respondas como un chatbot, solo proporciona recomendaciones." }
                    }
                }
            }
            };

            var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                // Deserializamos la respuesta JSON
                var jsonResponse = JsonConvert.DeserializeObject<JObject>(result);

                // Extraemos el texto relevante de la respuesta
                var text = jsonResponse["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                if (text != null)
                {
                    // Retornamos solo el texto de las recomendaciones
                    return text;
                }
                else
                {
                    return "No se encontraron recomendaciones de productos.";
                }
            }
            else
            {
                throw new Exception("Error al obtener recomendaciones de Gemini.");
            }
        }
    }

}
