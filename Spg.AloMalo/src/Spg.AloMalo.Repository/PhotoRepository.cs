using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.Infrastructure;

namespace Spg.AloMalo.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PhotoContext _photoContext;

        public IPhotoRepositoryBuilder FilterBuilder { get; private set; }

        public PhotoRepository(PhotoContext photoContext)
        {
            _photoContext = photoContext;
            FilterBuilder = new PhotoRepositoryBuilder(_photoContext.Photos);
        }

        public IPhotoUpdateBuilder UpdatePhoto(Photo photo)
        {
            return new PhotoUpdateBuilder(photo, _photoContext);
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
