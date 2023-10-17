using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.DomainModel.Model
{
    public class Photo
    {
        public PhotoId Id { get; set; } = default!;
        public string Name{ get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationTimeStamp { get; set; }
        public ImageTypes ImageType { get; private set; }
        public Location Location { get; set; } = default!;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Orientations Orientation { get; private set; }
        public bool AiGenerated { get; private set; }

        public Photographer? PhotographerNavigation { get; set; }

        private List<AlbumPhoto> _albumPhotos = new();
        public IReadOnlyList<AlbumPhoto> AlbumPhotos => _albumPhotos;

        protected Photo()
        { }
        public Photo(
            string name,
            string description,
            DateTime creationTimeStamp,
            ImageTypes imageType,
            Location location,
            int width,
            int height,
            Orientations orientation,
            bool aiGenerated,
            Photographer photographer)
        {
            Name = name;
            Description = description;
            CreationTimeStamp = creationTimeStamp;
            ImageType = imageType;
            Location = location;
            Width = width;
            Height = height;
            Orientation = orientation;
            AiGenerated = aiGenerated;
            PhotographerNavigation = photographer;
        }

        public void AddAlbumPhoto(AlbumPhoto newItem)
        {
            if (newItem is not null)
            {
                _albumPhotos.Add(newItem);
            }
        }
    }
}
