using Microsoft.EntityFrameworkCore;
using Spg.AloMalo.DomainModel.Model;
using Spg.AloMalo.Infrastructure.IdConverters;
using System.Reflection.Emit;

namespace Spg.AloMalo.Infrastructure
{
    public class PhotoContext : DbContext
    {
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<Album> Albums => Set<Album>();
        public DbSet<AlbumPhoto> AlbumPhotos => Set<AlbumPhoto>();
        public DbSet<Photographer> Photographers => Set<Photographer>();
        public DbSet<Person> Persons => Set<Person>();

        public PhotoContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Photographer>().OwnsOne(e => e.StudioAddress);
            builder.Entity<Photographer>().OwnsOne(e => e.BusinessPhoneNumber);
            builder.Entity<Photographer>().OwnsOne(e => e.MobilePhoneNumber);
            builder.Entity<Photographer>().OwnsOne(e => e.Username);
            builder.Entity<Person>().OwnsOne(e => e.Username);
            builder.Entity<Photo>().OwnsOne(e => e.Location);

            // Photographer -> EMails
            builder.Entity<Photographer>().OwnsMany(
                p => p.EMails, a =>
                {
                    a.WithOwner().HasForeignKey("PhotographerId");
                    a.Property<int>("Id");
                    a.HasKey("Id");
                });

            // Rich Types
            builder.Entity<Album>()
                .Property(p => p.Id)
                .HasConversion(new AlbumIdValueConverter())
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Photo>()
                .Property(p => p.Id)
                .HasConversion(new PhotoIdValueConverter())
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<AlbumPhoto>()
                .Property(p => p.Id)
                .HasConversion(new AlbumPhotoIdValueConverter())
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Photographer>()
                .Property(p => p.Id)
                .HasConversion(new PhotographerIdValueConverter())
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Person>()
                .Property(p => p.Id)
                .HasConversion(new PersonIdValueConverter())
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
