using Spg.AloMalo.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.Application.Services
{
    public class PhotoService
    {
        public PhotoService GetPhoto(PhotographerId photographerId, AlbumId albumId)
        {
            // photographerId = 4711
            // albumId = 123

            // DB: select * from photos where photographerId = 4711 and albumId = 123

            return null!;
        }
    }
}
