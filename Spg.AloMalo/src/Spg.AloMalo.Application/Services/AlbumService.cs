using Spg.AloMalo.DomainModel.Error;
using Spg.AloMalo.DomainModel.Exceptions;
using Spg.AloMalo.DomainModel.Interfaces;
using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.Infrastructure;

namespace Spg.AloMalo.Application.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly PhotoContext _db;

        public AlbumService(PhotoContext db)
        {
            _db = db;
        }

        public ErrorCheck<IQueryable<Album>> GetAllOk()
        {
            return new ErrorCheck<IQueryable<Album>>(_db.Albums);
        }

        public ErrorCheck<IQueryable<Album>> GetAll400()
        {
            throw new AlbumSerivceException("GetAll400(): Something went wrong!");
        }

        public ErrorCheck<IQueryable<Album>> GetAll404()
        {
            throw new ArgumentException("GetAll404(): Something went wrong!");
        }
    }
}
