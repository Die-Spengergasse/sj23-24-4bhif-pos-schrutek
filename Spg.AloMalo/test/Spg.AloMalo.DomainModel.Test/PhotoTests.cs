using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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

    private PhotoContext CreateDb()
    {
        SqliteConnection connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        DbContextOptions options = new DbContextOptionsBuilder()
            .UseSqlite(connection)
            .Options;

        PhotoContext db = new PhotoContext(options);
        db.Database.EnsureCreated();
        return db;
    }

    [Fact]
    public void Photo_ShouldInsertValidAlbums_WhenListNotNull()
    {
        using (PhotoContext db = CreateDb())
        {

            // Arrange
            Photographer newPhotographer = DatabaseUtilities.GetSeedingPhotographers()[0];
            Photo newPhoto = new Photo(
                "Test Photo 01",
                "Beschreibung Test Photo 01...",
                DateTime.Now,
                ImageTypes.Png,
                new Location(12, 17),
                400, 800,
                Orientations.Landscape,
                false,
                newPhotographer
            ).AddAlbums(new Album(
                "Test Album 01", "Beschreibung...",
                DateTime.Now,
                true,
                newPhotographer
            ));

            // Act
            db.Photos.Add(newPhoto);
            db.SaveChanges();

            // Assert
            Assert.Equal(1, db.Albums.Count());
            Assert.Equal(1, db.Photos.Count());
            Assert.Single(db.Albums.First().AlbumPhotos);
        }
    }

    [Fact]
    public void Photo_ShouldNotInsertValidAlbums_WhenListIsNull()
    {
        using (PhotoContext db = CreateDb())
        {
            // Arrange
            Photographer newPhotographer = DatabaseUtilities.GetSeedingPhotographers()[0];
            Photo newPhoto = new Photo(
                "Test Photo 01",
                "Beschreibung Test Photo 01...",
                DateTime.Now,
                ImageTypes.Png,
                new Location(12, 17),
                400, 800,
                Orientations.Landscape,
                false,
                newPhotographer
            ).AddAlbums(
                null!
            );

            // Act
            db.Photos.Add(newPhoto);
            db.SaveChanges();

            // Assert
            Assert.Equal(1, db.Albums.Count());
            //Assert.Empty(db.Photos);
            Assert.Empty(db.Albums.First().AlbumPhotos);
        }
    }
}