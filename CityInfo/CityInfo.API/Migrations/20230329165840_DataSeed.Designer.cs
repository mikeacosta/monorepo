﻿// <auto-generated />
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoDbContext))]
    [Migration("20230329165840_DataSeed")]
    partial class DataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Capital of the United Kingdom",
                            Name = "London"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Aloha",
                            Name = "Honolulu"
                        },
                        new
                        {
                            Id = 3,
                            Description = "There's no there there",
                            Name = "Oakland"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "One of London's oldest food markets",
                            Name = "Borough Market"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "Historic castle with over 1,000 years of history",
                            Name = "Tower of London"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Description = "This iconic landmark in Waikiki is one of Hawaii's most famous beaches",
                            Name = "Waikiki Beach"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Description = "Popular volcanic tuff cone on Oahu",
                            Name = "Diamond Head"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            Description = "Entertainment and business destination on the waterfront",
                            Name = "Jack London Square"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            Description = "Large tidal lagoon in the center of Oakland",
                            Name = "Lake Merritt"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Navigation("PointsOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}
