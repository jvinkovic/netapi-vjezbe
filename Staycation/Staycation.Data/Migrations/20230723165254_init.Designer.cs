﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Staycation.Data;

#nullable disable

namespace Staycation.Data.Migrations
{
    [DbContext(typeof(StaycationContext))]
    [Migration("20230723165254_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Staycation.Data.Entities.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Categorisation")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FreeCancellation")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("PersonCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Accommodations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categorisation = 4,
                            Description = "Family hotel",
                            FreeCancellation = false,
                            ImageUrl = "https://picsum.photos/800/600",
                            LocationId = 3,
                            PersonCount = 230,
                            Price = 133.99m,
                            Subtitle = "Your getaway",
                            Title = "Adama",
                            Type = "Hotel"
                        },
                        new
                        {
                            Id = 2,
                            Categorisation = 4,
                            Description = "Villa in Nafplion",
                            FreeCancellation = true,
                            ImageUrl = "https://picsum.photos/800/600",
                            LocationId = 3,
                            PersonCount = 310,
                            Price = 199.99m,
                            Subtitle = "Villa",
                            Title = "CasaKrystal",
                            Type = "Villa"
                        },
                        new
                        {
                            Id = 3,
                            Categorisation = 3,
                            Description = "Cozy studio near big parks",
                            FreeCancellation = true,
                            ImageUrl = "https://picsum.photos/800/600",
                            LocationId = 4,
                            PersonCount = 230,
                            Price = 49.99m,
                            Subtitle = "Apartment in heart of Osijek",
                            Title = "Epoketa",
                            Type = "Apartment"
                        });
                });

            modelBuilder.Entity("Staycation.Data.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://images2.imgbox.com/66/33/4ll057fa_o.jpg",
                            Name = "Argos",
                            PostalCode = "21200"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://images2.imgbox.com/62/d7/3rJYe9p9_o.jpg",
                            Name = "Chania",
                            PostalCode = "74212"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://images2.imgbox.com/34/8f/yeONFHwj_o.jpg",
                            Name = "Nafplion",
                            PostalCode = "21100"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://images2.imgbox.com/fd/3b/xYT7BlSR_o.jpg",
                            Name = "Osijek",
                            PostalCode = "31000"
                        });
                });

            modelBuilder.Entity("Staycation.Data.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccommodationId = 3,
                            Confirmed = true,
                            Email = "mjmail@himail.com",
                            PersonCount = 2
                        },
                        new
                        {
                            Id = 2,
                            AccommodationId = 1,
                            Confirmed = true,
                            Email = "pero@himail.com",
                            PersonCount = 9
                        },
                        new
                        {
                            Id = 3,
                            AccommodationId = 3,
                            Confirmed = true,
                            Email = "lara@himail.com",
                            PersonCount = 4
                        },
                        new
                        {
                            Id = 4,
                            AccommodationId = 2,
                            Confirmed = true,
                            Email = "info@gert.hr",
                            PersonCount = 5
                        });
                });

            modelBuilder.Entity("Staycation.Data.Entities.Accommodation", b =>
                {
                    b.HasOne("Staycation.Data.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Staycation.Data.Entities.Reservation", b =>
                {
                    b.HasOne("Staycation.Data.Entities.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");
                });
#pragma warning restore 612, 618
        }
    }
}