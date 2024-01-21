using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Spg.AloMalo.DomainModel.Commands;
using Spg.AloMalo.DomainModel.Exceptions;
using Spg.AloMalo.DomainModel.Interfaces;
using Spg.AloMalo.DomainModel.Model;

namespace Spg.AloMalo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
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

        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet()]
        public IActionResult GetPhoto()
        {
            // Deswegen Rich Typed IDs
            var r = _photoService.GetWhatEver(new PhotoId(123), new AlbumId(456), new PhotographerId(147));

            // bloß Daten holen...
            return Ok(_photoService.GetPhoto());
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatePhoto(CreatePhotoCommand command)
        {
            // Try-Catch-Blöcke im Controller sind richtig HÄSSLICH!
            // (Lösung im AlbumController)
            try
            {
                return Created("", _photoService.Create(command));
            }
            catch (PhotoServiceCreateException)
            {
                return NotFound();
            }
            catch (PhotoServiceValidationException)
            {
                return BadRequest();
            }
            // catch (...)
            // ...
        }
    }
}
