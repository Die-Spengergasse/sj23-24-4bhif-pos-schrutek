using Spg.AloMalo.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.Repository
{
    public interface IPhotoRepositoryBuilder
    {
        IQueryable<Photo> Photos { get; set; }

        IPhotoRepositoryBuilder ApplayNameContainsFilter(string filter);

        IQueryable<Photo> Build();
    }
}
