using Spg.AloMalo.DomainModel.Commands;
using Spg.AloMalo.DomainModel.Interfaces;
using Spg.AloMalo.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.Application.Services
{
    public class PhotoServiceWrapper : IPhotoService
    {
        private readonly IPhotoService _photoService;

        public PhotoServiceWrapper(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public Photo Create(CreatePhotoCommand command)
        {
            return _photoService.Create(command);
        }

        public IQueryable<Photo> GetPhoto()
        {
            return _photoService.GetPhoto();
        }

        public IQueryable<Photo> GetWhatEver(PhotoId photoId, AlbumId albumId, PhotographerId photograperId)
        {
            return _photoService.GetWhatEver(photoId, albumId, photograperId);
        }
    }
}
