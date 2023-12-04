using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.AloMalo.Application.Services;
using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.Repository;

namespace Spg.AloMalo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        // GET:  Liefert alle Produkte
        // http://www.myservice.at/products
        // POST: Legt neues produkt an
        // http://www.myservice.at/products     (+ Content im Body)
        // GET: Liefert ein Produkt
        // http://www.myservice.at/products/[GUID]
        // DELETE: Löscht ein Produkt
        // http://www.myservice.at/products/[GUID]
        // PUT: Aktualisiert ein Produkt
        // http://www.myservice.at/products/[GUID]     (+ Content im Body)
        // PATCH: Aktualisiert einen Teil eines Produkts
        // http://www.myservice.at/products/[GUID]     (+ Content im Body)

        // GET: Liefert Produkte gefiltert nach Namensteil
        // http://www.myservice.at/products?name_contains=weihnacht&state=verfuegbar&.........

        // GET: Liefert alle Produkte in einem Warenkorb eines Kunden
        // http://www.myservice.at/schoppingcart/[Customer-GUID]/products?.....


        [HttpGet()]
        public IActionResult GetPhoto()
        {
            // TODO: Implementation
            return Ok(new PhotoService()
                .GetPhoto());
        }
    }
}
