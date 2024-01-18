using Spg.AloMalo.DomainModel.Model;

namespace Spg.AloMalo.Repository
{
    public class PhotoRepositoryBuilder : IPhotoRepositoryBuilder
    {
        public IQueryable<Photo> Photos { get; set; }

        public PhotoRepositoryBuilder(IQueryable<Photo> photos)
        {
            Photos = photos;
        }

        public IPhotoRepositoryBuilder ApplayNameContainsFilter(string name)
        {
            Photos = Photos.Where(x => x.Name.Contains(name));
            return this;
        }

        public IQueryable<Photo> Build()
        {
            return Photos;
        }
    }
}
