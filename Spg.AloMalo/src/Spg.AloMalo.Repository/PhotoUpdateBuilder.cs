using Microsoft.EntityFrameworkCore;
using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.Repository
{
    /// <summary>
    /// https://betterprogramming.pub/the-power-of-extension-methods-b3b1962475c4
    /// </summary>
    public class PhotoUpdateBuilder : IPhotoUpdateBuilder
    {
        private readonly PhotoContext _db;
        private readonly Photo _photo;

        public PhotoUpdateBuilder(Photo photo, PhotoContext db)
        {
            _db = db;
            _photo = photo;
        }
        public IPhotoUpdateBuilder WithName(string name)
        {
            _photo.Name = name;
            //_db.Update(_photo);
            return this;
        }

        public IPhotoUpdateBuilder WithOrientation(Orientations orientation)
        {
            _photo.Orientation = orientation;
            //_db.Update(_photo);
            return this;
        }

        public int Save()
        {
            _db.Update(_photo);
            return _db.SaveChanges();
        }
    }
}
