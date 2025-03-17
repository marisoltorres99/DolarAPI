using DolarAPI.Models;
using System.Text.Json;

namespace DolarAPI.Services
{
    public class DolarService : IDolarService
    {
        private readonly HttpClient _httpClient;

        public DolarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CotizacionDolar?> ObtenerCotizacionDolar(string tipo)
        {
            var response = await _httpClient.GetAsync(tipo.ToLower());
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var cotizacion = JsonSerializer.Deserialize<CotizacionDolar>(json, options);

            return cotizacion;
        }
    }
}
