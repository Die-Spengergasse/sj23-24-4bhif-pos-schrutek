using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.DomainModel.Model
{
    public class Album
    {
        public AlbumId Id { get; set; } = default!;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationTimeStamp  { get; private set; }
        public bool Private { get; set; }
        
        public Photographer Owner { get; set; } = default!;

        private List<AlbumPhoto> _albumPhotos = new();
        public IReadOnlyList<AlbumPhoto> AlbumPhotos => _albumPhotos;

        protected Album()
        { }
        public Album(
            string name, 
            string description, 
            DateTime creationTimeStamp, 
            bool @private, 
            Photographer owner)
        {
            Name = name;
            Description = description;
            CreationTimeStamp = creationTimeStamp;
            Private = @private;
            Owner = owner;
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
