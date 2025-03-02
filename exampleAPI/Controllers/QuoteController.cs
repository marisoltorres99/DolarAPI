using exampleAPI.Model;
using exampleAPI.Resource;
using Microsoft.AspNetCore.Mvc;

namespace exampleAPI.Controllers
{
    // este atributo define la ruta base para las acciones dentro del
    // controlador."api/Quote" es el prefijo de la URL que se debe usar
    // para acceder a los endpoints en este controlador.
    [Route("api/Quote")]
    // define la clase como controlador de API con sus propiedades y metodos
    [ApiController]
    
    // hereda de Controller
    public class QuoteController : Controller
    {
        // configura el método como un endpoint HTTP GET y asigna un nombre único a la ruta de esa acción
        [HttpGet(Name = "GetQuote")]

        // metodo get que devuelve la cotizacion del dolar blue (string)
        public string GetQuote()
        {
            // creo un objeto de la clase DolarAPI
            DolarAPI api = new DolarAPI();

            // llamo al metodo GetQuote de la clase DolarAPI
            return api.GetQuote().Result;
        }

        // configura el método como un endpoint HTTP POST y asigna un nombre único a la ruta de esa acción
        [HttpPost(Name = "GetSpecificQuote")]

        // metodo post que devuelve un objeto de tipo Currency (devuelve la cotizacion del tipo de dolar especificado)
        // FromBody indica que el parametro a recibir esta en el cuerpo del mensaje
        public async Task<string> GetSpecificQuote([FromBody] Currency Currency)
        {
            // creo un objeto de la clase DolarAPI
            DolarAPI api = new DolarAPI();
            // llamo al metodo GetSpecificQuote de la clase DolarAPI con el parametro Currency que tiene el tipo de dolar especificado
            return await api.GetSpecificQuote(Currency);
        }
    }
}
