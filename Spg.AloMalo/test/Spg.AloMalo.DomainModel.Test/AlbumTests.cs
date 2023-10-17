using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.DomainModel.Test.Helpers;
using Spg.AloMalo.Infrastructure;

namespace Spg.AloMalo.DomainModel.Test;

public class AlbumTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _databaseFixture;

    public AlbumTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public void Album_ShouldCreate_WhenEntitiesComplete()
    {
        using (PhotoContext db = _databaseFixture.Db)
        {
            // Arrange
            Photographer newPhotographer = new Photographer(
                "Martin",
                "Schrutek",
                new Address("Photo Street", "1234", "Photoville", "Photanien"),
                new PhoneNumber(43, 1234, "123456789"),
                new PhoneNumber(43, 1234, "123456789"),
                new EMail("schrutek@spengergasse.at"),
                new EMail("schrutek@spengergasse.at")
            );
            Album newAlbum1 = new Album(
                "Test Album 01", "Beschreibung...",
                DateTime.Now,
                true,
                newPhotographer
            );
            Album newAlbum2 = new Album(
                "Test Album 02", "Beschreibung...",
                DateTime.Now,
                true,
                newPhotographer
            );

            // Act
            _databaseFixture.Db.Albums.Add(newAlbum1);
            _databaseFixture.Db.Albums.Add(newAlbum2);
            _databaseFixture.Db.SaveChanges();

            // Assert
            Assert.Equal(2, _databaseFixture.Db.Albums.Count());
        }
    }
}