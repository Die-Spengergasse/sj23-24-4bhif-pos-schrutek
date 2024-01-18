using Spg.AloMalo.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.DomainModel.Commands
{
    public record CreatePhotoCommand(
        string Name, 
        string Description, 
        ImageTypes ImageType, 
        Location Location, 
        int Width, 
        int Height, 
        Orientations Orientation, 
        bool AiGenerated);
}
