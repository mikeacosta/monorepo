﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TownTalk.API.DbContexts;

#nullable disable

namespace TownTalk.API.Migrations
{
    [DbContext(typeof(TownTalkContext))]
    [Migration("20240516023324_InitialDataSeed")]
    partial class InitialDataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TownTalk.API.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("TownId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("PointsOfInterest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "One of London's oldest food markets",
                            Name = "Borough Market",
                            TownId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Historic castle with over 1,000 years of history",
                            Name = "Tower of London",
                            TownId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "This iconic landmark in Waikiki is one of Hawaii's most famous beaches",
                            Name = "Waikiki Beach",
                            TownId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Popular volcanic tuff cone on Oahu",
                            Name = "Diamond Head",
                            TownId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Entertainment and business destination on the waterfront",
                            Name = "Jack London Square",
                            TownId = 3
                        },
                        new
                        {
                            Id = 6,
                            Description = "Large tidal lagoon in the center of Oakland",
                            Name = "Lake Merritt",
                            TownId = 3
                        });
                });

            modelBuilder.Entity("TownTalk.API.Entities.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Towns");

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

            modelBuilder.Entity("TownTalk.API.Entities.PointOfInterest", b =>
                {
                    b.HasOne("TownTalk.API.Entities.Town", "Town")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Town");
                });

            modelBuilder.Entity("TownTalk.API.Entities.Town", b =>
                {
                    b.Navigation("PointsOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}
