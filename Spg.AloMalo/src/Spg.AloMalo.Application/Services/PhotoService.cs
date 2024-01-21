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

        public PhotoService(ILogger<PhotoService> logger, IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
            _logger = logger;
        }

        public IQueryable<Photo> GetWhatEver(PhotoId photoId, AlbumId albumId, PhotographerId photograperId)
        {
            // LINQ: photoId, albumId, photograperId
            return null!;
        }


        public IQueryable<Photo> GetPhoto()
        {
            IQueryable<Photo> result = _photoRepository
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
            if (string.IsNullOrEmpty(command.Name))
            {
                throw PhotoServiceValidationException.FromLastNameRequired();
            }

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

            return null!;
        }

        public void Update(Photo photo)
        {
            // Bad!
            // photos.Update(string name, string description, bool ai, int width, int height, ...)
            // photos.Update(string name)
            // photos.Update(int width, int height, ...)
            // Put, Patch

            // Better!
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
