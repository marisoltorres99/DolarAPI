using DolarAPI.Models;
using DolarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolarController : ControllerBase
    {
        private readonly IDolarService _dolarService;

        public DolarController(IDolarService dolarService)
        {
            _dolarService = dolarService;
        }

        [HttpGet("{tipo}")]
        public async Task<ActionResult<CotizacionDolar?>> ObtenerCotizacion(string tipo)
        {
            var cotizacion = await _dolarService.ObtenerCotizacionDolar(tipo);
            if (cotizacion == null)
                return NotFound(new { mensaje = "Tipo de dólar no encontrado" });

            return Ok(cotizacion);
        }

        [HttpGet("{tipo}/{cantidad}")]
        public async Task<ActionResult<decimal?>> ConvertirAPesos(string tipo, decimal cantidad)
        {
            var cotizacion = await _dolarService.ObtenerCotizacionDolar(tipo);
            if (cotizacion == null)
                return NotFound(new { mensaje = "Tipo de dólar no encontrado" });

            decimal pesos = 0;

            pesos = cantidad * cotizacion.Venta;

            return Ok(pesos);
        }
    }
}
