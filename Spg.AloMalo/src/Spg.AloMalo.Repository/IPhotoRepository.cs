using Spg.AloMalo.DomainModel.Model;

namespace Spg.AloMalo.Repository
{
    public interface IPhotoRepository
    {
        IPhotoRepositoryBuilder FilterBuilder { get; }

        IPhotoUpdateBuilder UpdatePhoto(Photo photo);
        void Create();
        void Delete();
    }
}
