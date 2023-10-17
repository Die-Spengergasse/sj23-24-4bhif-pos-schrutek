using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.AloMalo.Application.Services;
using Spg.AloMalo.DomainModel.Model;

namespace Spg.AloMalo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        public IActionResult GetPhoto()
        {
            return StatusCode(501, new PhotoService().GetPhoto(new PhotographerId(4711), new AlbumId(123)));
        }
    }
}
