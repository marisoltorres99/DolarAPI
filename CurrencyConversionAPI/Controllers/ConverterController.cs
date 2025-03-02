using CurrencyConversionAPI.Resource;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConversionAPI.Controllers
{
    // configuracion de la ruta de la API
    [Route("api/Controller")]
    [ApiController]
    public class ConverterController : Controller
    {
        [HttpGet(Name = "GetQuote")]
        
        //metodo de tipo get (el parametro a recibir se lo mando desde la cabecera)
        public async Task<string> GetQuote([FromQuery] decimal value)
        {
            // creo un objeto ExampleAPI para llamar a los metodos que obtendran las cotizaciones
            ExampleAPI api = new ExampleAPI();
            decimal result = await api.GetSpecificQuote();
            // devuelve el valor del dolar multiplicado por la cantidad ingresada
            return (result * value).ToString();
        }
    }
}
