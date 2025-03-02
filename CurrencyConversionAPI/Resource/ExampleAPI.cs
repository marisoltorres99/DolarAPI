using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; // deserializacion desde json
using System.Net.Http.Headers; // configuracion de encabezados HTTP
using System.Text;
using Nancy.Json; // serializacion de objetos en formato json
using System.Web.Http; // excepciones de controladores de API

namespace CurrencyConversionAPI.Resource
{
    public class ExampleAPI
    {
        // obtiene cotizacion del tipo especifico de dolar desde la otra API creada
        public async Task<decimal> GetSpecificQuote()
        {
            // respuesta http
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                // tiene el tipo de moneda a buscar, en este caso Bolsa
                RequestCurrency currency = new RequestCurrency();
                currency.Code = "Bolsa";

                // convierto a formato json
                var jsonObject = new JavaScriptSerializer().Serialize(currency);
                //define el contenido de la solicitud HTTP
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                // configura encabezados de la solicitud
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                // solicitud POST a la API
                response = await client.PostAsync("https://localhost:7277/api/Quote", content);
                // verificacion de la respuesta
                if (!response.IsSuccessStatusCode)
                {
                    // manejo de la excepcion en caso de encontrarla
                    var httpResponse = new HttpResponseMessage(response.StatusCode);
                    httpResponse.ReasonPhrase = " CONNECTION ERROR";
                    httpResponse.Content = new StringContent("");
                    throw new HttpResponseException(httpResponse);
                }
            }
                // leo y deserializo respuesta json a objeto QuoteCurrencyResponse
                string str = response.Content.ReadAsStringAsync().Result;
                QuoteCurrencyResponse? result = JsonConvert.DeserializeObject<QuoteCurrencyResponse?>(str);
                // devuelve el valor del atributo Venta
                return result.Venta;
        }
    }
}