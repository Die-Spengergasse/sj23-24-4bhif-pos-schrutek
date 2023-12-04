using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.Repository
{
    public interface IPhotoUpdateBuilder
    {
        IPhotoUpdateBuilder WithName(string name);
        IPhotoUpdateBuilder WithOrientation(Orientations orientation);
        int Save();
    }
}
