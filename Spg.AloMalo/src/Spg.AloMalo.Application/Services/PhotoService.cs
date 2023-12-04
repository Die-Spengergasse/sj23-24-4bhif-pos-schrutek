using Microsoft.EntityFrameworkCore;
using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.Infrastructure;
using Spg.AloMalo.Repository;
using Spg.AloMalo.Repository.Extensions;

namespace Spg.AloMalo.Application.Services
{
    public class PhotoService
    {
        private readonly PhotoContext _dbContext;
        private readonly IPhotoRepository _photoRepository;

        public PhotoService()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlite("Data Source=C:\\HTL\\Unterricht\\SJ2324\\4BHIF\\POS\\sj23-24-4bhif-pos-schrutek\\Spg.AloMalo\\Photo.db");

            _dbContext = new PhotoContext(dbContextOptionsBuilder.Options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            SeedHelper.Seed(_dbContext);

            _photoRepository = new PhotoRepository(_dbContext);
        }

        public IQueryable<Photo> GetPhoto()
        {
            IQueryable<Photo> result = new PhotoRepository(_dbContext)
                .FilterBuilder
                .ApplyOrientationFilter(Orientations.Landscape)
                .ApplayNameContainsFilter("My")
                .ApplayNameContainsFilter("a")
                .Build();

            return result;
        }

        public void Update(Photo photo) 
        {
            // mit Repository-Pattern
            _photoRepository
                .UpdatePhoto(GetPhoto().First())
                .WithName("New Name 2")
                .WithOrientation(Orientations.Portrait)
                .Save();

            // ohne Repository-Pattern
            _dbContext
                .UpdatePhoto(GetPhoto().First())
                .WithName("New Name")
                .WithDescription("New Description of this Photo (updated)!")
                .WithOrienatation(Orientations.Portrait)
                .Save();
        }
    }
}
