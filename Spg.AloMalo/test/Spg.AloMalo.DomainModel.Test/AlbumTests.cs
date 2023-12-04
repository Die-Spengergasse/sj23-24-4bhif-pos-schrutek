using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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

    public PhotoContext CreateDb()
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
    public void Album_ShouldCreate_WhenEntitiesComplete()
    {
        using (PhotoContext db = CreateDb())
        {
            // Arrange
            Photographer newPhotographer = DatabaseUtilities.GetSeedingPhotographers()[0];
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
            db.Albums.Add(newAlbum1);
            db.Albums.Add(newAlbum2);
            db.SaveChanges();

            // Assert
            Assert.Equal(2, db.Albums.Count());
        }
    }

    [Fact]
    public void Album_ShouldInsertValidPhotos_WhenListNotNull()
    {
        using (PhotoContext db = CreateDb())
        {
            // Arrange
            Photographer newPhotographer = DatabaseUtilities.GetSeedingPhotographers()[0];
            Album newAlbum = new Album(
                "Test Album 01", "Beschreibung...",
                DateTime.Now,
                true,
                newPhotographer
            ).AddPhotos(new List<Photo>()
            {
                new Photo("Test Photo 01",
                    "Beschreibung Test Photo 01...",
                    DateTime.Now,
                    ImageTypes.Png,
                    new Location(12, 17),
                    400, 800,
                    Orientations.Landscape,
                    false,
                    newPhotographer),
            });

            // Act
            db.Albums.Add(newAlbum);
            db.SaveChanges();

            // Assert
            Assert.Equal(1, db.Albums.Count());
            Assert.Equal(1, db.Photos.Count());
            Assert.Single(db.Albums.First().AlbumPhotos);
        }
    }

    [Fact]
    public void Album_ShouldNotInsertValidPhotos_WhenListIsNull()
    {
        using (PhotoContext db = CreateDb())
        {
            // Arrange
            Photographer newPhotographer = DatabaseUtilities.GetSeedingPhotographers()[0];
            Album newAlbum = new Album(
                "Test Album 01", "Beschreibung...",
                DateTime.Now,
                true,
                newPhotographer
            ).AddPhotos(
                null!
            );

            // Act
            db.Albums.Add(newAlbum);
            db.SaveChanges();

            // Assert
            Assert.Equal(1, db.Albums.Count());
            Assert.Empty(db.Photos);
            Assert.Empty(db.Albums.First().AlbumPhotos);
        }
    }
}