using Spg.AloMalo.DomainModel.Model;

namespace Spg.AloMalo.Repository.Extensions
{
    public static class FilterPhotoExtensions
    {
        public static IPhotoRepositoryBuilder ApplyOrientationFilter(this IPhotoRepositoryBuilder builder, Orientations orientation)
        {
            builder.Photos = builder.Photos.Where(x => x.Orientation == orientation);
            return builder;
        }

        public static IPhotoRepositoryBuilder ApplayAiFilter(this IPhotoRepositoryBuilder builder, bool @is)
        {
            builder.Photos = builder.Photos.Where(x => x.AiGenerated == @is);
            return builder;
        }
    }
}
