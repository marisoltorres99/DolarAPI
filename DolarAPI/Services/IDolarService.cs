using DolarAPI.Models;

namespace DolarAPI.Services
{
    public interface IDolarService
    {
        Task<CotizacionDolar?> ObtenerCotizacionDolar(string tipo);
    }
}
