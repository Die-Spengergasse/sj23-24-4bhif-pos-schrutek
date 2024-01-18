using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Spg.AloMalo.DomainModel.Commands;
using Spg.AloMalo.DomainModel.Exceptions;
using Spg.AloMalo.DomainModel.Interfaces;
using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.Infrastructure;
using Spg.AloMalo.Repository;
using Spg.AloMalo.Repository.Extensions;

namespace Spg.AloMalo.Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly PhotoContext _dbContext;
        private readonly IPhotoRepository _photoRepository;
        private readonly ILogger<PhotoService> _logger;

        public PhotoService(ILogger<PhotoService> logger)
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlite("Data Source=C:\\HTL\\Unterricht\\SJ2324\\4BHIF\\POS\\sj23-24-4bhif-pos-schrutek\\Spg.AloMalo\\Photo.db");

            _dbContext = new PhotoContext(dbContextOptionsBuilder.Options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            SeedHelper.Seed(_dbContext);

            _photoRepository = new PhotoRepository(_dbContext);
            _logger = logger;
        }

        public IQueryable<Photo> GetWhatEver(PhotoId photoId, AlbumId albumId, PhotographerId photograperId)
        {
            // LINQ: photoId, albumId, photograperId
            return null!;
        }


        public IQueryable<Photo> GetPhoto()
        {
            IQueryable<Photo> result = new PhotoRepository(_dbContext)
                .FilterBuilder
                .ApplyOrientationFilter(Orientations.Landscape)
                .ApplayNameContainsFilter("My")
                .ApplayNameContainsFilter("a")
                .ApplayAiFilter(true)
                .ApplayNameContainsFilter("hello")
                .Build();

            return result;
        }

        public Photo Create(CreatePhotoCommand command)
        {
            _logger.LogDebug("Initalisation");

            _logger.LogDebug("Validation");

            _logger.LogDebug("Action");

            try
            {
                _logger.LogDebug("Save");

                _logger.LogInformation("Successfully saved");
            }
            catch (Exception)
            {
                _logger.LogError("save failed");
                throw PhotoServiceCreateException.FromSave();
            }

            return null;   
        }

        public void Update(Photo photo)
        {
            // photos.Update(string name, string description, bool ai, int width, int height, ...)
            // photos.Update(string name)
            // photos.Update(int width, int height, ...)
            // Put, Patch

            // mit Repository-Pattern
            _photoRepository
                .UpdatePhoto(GetPhoto().First())
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
