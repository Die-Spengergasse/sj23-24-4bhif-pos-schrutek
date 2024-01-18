using Spg.AloMalo.DomainModel.Commands;
using Spg.AloMalo.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.DomainModel.Interfaces
{
    public interface IPhotoService
    {
        IQueryable<Photo> GetWhatEver(PhotoId photoId, AlbumId albumId, PhotographerId photograperId);
        IQueryable<Photo> GetPhoto();
        Photo Create(CreatePhotoCommand command);
    }
}
