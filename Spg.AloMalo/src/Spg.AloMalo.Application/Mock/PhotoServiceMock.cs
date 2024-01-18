using Spg.AloMalo.DomainModel.Commands;
using Spg.AloMalo.DomainModel.Interfaces;
using Spg.AloMalo.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.Application.Mock
{
    public class PhotoServiceMock : IPhotoService
    {
        public Photo Create(CreatePhotoCommand command)
        {
            // Info:Create aber nicht in die echte DB sondern in eine Fake-Db oder Liste 
            throw new NotImplementedException();
        }

        public IQueryable<Photo> GetPhoto()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Photo> GetWhatEver(PhotoId photoId, AlbumId albumId, PhotographerId photograperId)
        {
            throw new NotImplementedException();
        }
    }
}
