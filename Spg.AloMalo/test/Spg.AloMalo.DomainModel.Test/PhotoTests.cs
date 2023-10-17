using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.DomainModel.Test.Helpers;
using Spg.AloMalo.Infrastructure;

namespace Spg.AloMalo.DomainModel.Test;

public class PhotoTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _databaseFixture;

    public PhotoTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public void Photo_ShouldCreate_WhenEntitiesComplete()
    {
        using (PhotoContext db = _databaseFixture.Db)
        {
            // Arrange
            Photographer newPhotographer = new(
                "Martin",
                "Schrutek",
                new Address("Photo Street", "1234", "Photoville", "Photanien"),
                new PhoneNumber(43, 1234, "123456789"),
                new PhoneNumber(43, 1234, "123456789"),
                new List<EMail>() { new EMail("schrutek@spengergasse.at"), new EMail("schrutek2@spengergasse.at") },
                new EMail("schrutek@spengergasse.at")
            );
            Album newAlbum = new(
                "Test Album 01", "Beschreibung...",
                DateTime.Now,
                true,
                newPhotographer
            );
            Photo newPhoto = new(
                "Test Photo 01",
                "Beschreibung Test Photo 01...",
                DateTime.Now,
                ImageTypes.Png,
                new Location(12, 17),
                400,
                800,
                Orientations.Landscape,
                false,
                newPhotographer
            );
            AlbumPhoto newAlbumPhoto = new(
                newAlbum,
                newPhoto,
                1);
            newAlbum.AddAlbumPhoto(newAlbumPhoto);
            newPhoto.AddAlbumPhoto(newAlbumPhoto);

            // Act
            db.Albums.Add(newAlbum);
            db.Photos.Add(newPhoto);
            db.SaveChanges();

            // Assert
            Assert.Single(db.Albums);
            Assert.Single(db.Photos);
            Assert.Single(db.AlbumPhotos);
        }
    }
}