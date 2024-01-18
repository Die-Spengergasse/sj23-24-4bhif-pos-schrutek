﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spg.AloMalo.Infrastructure;

#nullable disable

namespace Spg.AloMalo.Infrastructure.Migrations
{
    [DbContext(typeof(PhotoContext))]
    [Migration("20231207080916_Payment_added")]
    partial class Payment_added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<bool>("Private")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.AlbumPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumNavigationId")
                        .HasColumnType("int");

                    b.Property<int>("PhotoNavigationId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumNavigationId");

                    b.HasIndex("PhotoNavigationId");

                    b.ToTable("AlbumPhoto");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AiGenerated")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Orientation")
                        .HasColumnType("int");

                    b.Property<int?>("PhotographerNavigationId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotographerNavigationId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photographer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photographers");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Album", b =>
                {
                    b.HasOne("Spg.AloMalo.DomainModel.Model.Photographer", "Owner")
                        .WithMany("Albums")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.AlbumPhoto", b =>
                {
                    b.HasOne("Spg.AloMalo.DomainModel.Model.Album", "AlbumNavigation")
                        .WithMany("AlbumPhotos")
                        .HasForeignKey("AlbumNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spg.AloMalo.DomainModel.Model.Photo", "PhotoNavigation")
                        .WithMany("AlbumPhotos")
                        .HasForeignKey("PhotoNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlbumNavigation");

                    b.Navigation("PhotoNavigation");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Person", b =>
                {
                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.EMail", "Username", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId");

                            b1.ToTable("Persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photo", b =>
                {
                    b.HasOne("Spg.AloMalo.DomainModel.Model.Photographer", "PhotographerNavigation")
                        .WithMany("Photos")
                        .HasForeignKey("PhotographerNavigationId");

                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.Location", "Location", b1 =>
                        {
                            b1.Property<int>("PhotoId")
                                .HasColumnType("int");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.HasKey("PhotoId");

                            b1.ToTable("Photos");

                            b1.WithOwner()
                                .HasForeignKey("PhotoId");
                        });

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("PhotographerNavigation");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photographer", b =>
                {
                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.Address", "StudioAddress", b1 =>
                        {
                            b1.Property<int>("PhotographerId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PhotographerId");

                            b1.ToTable("Photographers");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");

                            b1.OwnsOne("Spg.AloMalo.DomainModel.Model.State", "State", b2 =>
                                {
                                    b2.Property<int>("AddressPhotographerId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("StateName");

                                    b2.HasKey("AddressPhotographerId");

                                    b2.ToTable("Photographers");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressPhotographerId");
                                });

                            b1.Navigation("State")
                                .IsRequired();
                        });

                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.PhoneNumber", "BusinessPhoneNumber", b1 =>
                        {
                            b1.Property<int>("PhotographerId")
                                .HasColumnType("int");

                            b1.Property<int>("AreaCode")
                                .HasColumnType("int");

                            b1.Property<int>("CountryCode")
                                .HasColumnType("int");

                            b1.Property<string>("SerialNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PhotographerId");

                            b1.ToTable("Photographers");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");
                        });

                    b.OwnsMany("Spg.AloMalo.DomainModel.Model.EMail", "EMails", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PhotographerId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("PhotographerId");

                            b1.ToTable("Photographers_EMails");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");
                        });

                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.PhoneNumber", "MobilePhoneNumber", b1 =>
                        {
                            b1.Property<int>("PhotographerId")
                                .HasColumnType("int");

                            b1.Property<int>("AreaCode")
                                .HasColumnType("int");

                            b1.Property<int>("CountryCode")
                                .HasColumnType("int");

                            b1.Property<string>("SerialNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PhotographerId");

                            b1.ToTable("Photographers");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");
                        });

                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.EMail", "Username", b1 =>
                        {
                            b1.Property<int>("PhotographerId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PhotographerId");

                            b1.ToTable("Photographers");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");
                        });

                    b.Navigation("BusinessPhoneNumber")
                        .IsRequired();

                    b.Navigation("EMails");

                    b.Navigation("MobilePhoneNumber")
                        .IsRequired();

                    b.Navigation("StudioAddress")
                        .IsRequired();

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Album", b =>
                {
                    b.Navigation("AlbumPhotos");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photo", b =>
                {
                    b.Navigation("AlbumPhotos");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photographer", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}