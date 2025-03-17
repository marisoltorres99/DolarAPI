# DolarAPI
Una API desarrollada con .NET Core que permite consultar las cotizaciones de diferentes tipos de dólares en Argentina y realizar conversiones entre dólares y pesos argentinos.

Descripción

Este proyecto es una API que permite consultar la cotización del dólar en diferentes tipos, como el dólar blue y el dólar oficial, a través de un servicio externo. Además, ofrece un endpoint para convertir una cantidad en dólares a su equivalente en pesos argentinos, utilizando la cotización de la venta.

Características

    Consulta de cotización: Permite consultar la cotización de los tipos de dólar más comunes (blue, oficial).

    Conversión a pesos: Calcula la conversión de una cantidad de dólares a pesos argentinos según la cotización correspondiente.

    Documentación: Genera documentación de la API con Swagger para facilitar el uso.

Endpoints
1. Obtener cotización de un tipo de dólar

URL: /api/dolar/{tipo}

Método: GET

Descripción:
Este endpoint devuelve la cotización de un tipo de dólar (por ejemplo, blue u oficial).

Parámetros:

    tipo (string): El tipo de dólar a consultar. Puede ser blue, oficial, entre otros.

Ejemplo de solicitud:
GET /api/dolar/blue

Respuesta exitosa (200 OK):
{
    "nombre": "Blue",
    "compra": 1220,
    "venta": 1240
}

Respuesta de error (404 Not Found):
{
    "mensaje": "Tipo de dólar no encontrado"
}

2. Convertir dólares a pesos

URL: /api/dolar/convertirapesos/{tipo}/{cantidad}
Método: GET

Descripción:

Este endpoint convierte una cantidad de dólares a pesos, usando la cotización de venta correspondiente al tipo de dólar proporcionado.

Parámetros:

    tipo (string): El tipo de dólar. Puede ser blue, oficial, entre otros.

    cantidad (decimal): La cantidad de dólares a convertir.

Ejemplo de solicitud:

GET /api/dolar/convertirapesos/blue/100

Respuesta exitosa (200 OK):
499040

Tecnologías utilizadas

    .NET 8: Framework principal utilizado para desarrollar la API.

    Swagger: Para la generación de la documentación de la API.

    HttpClient: Para realizar las solicitudes a la API externa que proporciona las cotizaciones.
