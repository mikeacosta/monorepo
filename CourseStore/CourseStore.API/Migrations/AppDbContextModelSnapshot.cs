﻿// <auto-generated />
using System;
using CourseStore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CourseStore.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CourseStore.API.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b863cb7-d866-4322-8e2c-136518f08855"),
                            FirstName = "Daniel",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            Id = new Guid("5070b038-5bd7-45b6-94ec-ad1483384997"),
                            FirstName = "Fred",
                            LastName = "Jones"
                        });
                });

            modelBuilder.Entity("CourseStore.API.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eb57b0d1-7d07-4d1a-81ae-10c2555a78a3"),
                            AuthorId = new Guid("7b863cb7-d866-4322-8e2c-136518f08855"),
                            Description = "Comprehensive overview of the scientific study of thought and behavior",
                            Title = "Introduction to Psychology"
                        },
                        new
                        {
                            Id = new Guid("2de47cda-cbd9-4f00-9e5a-6912c37a6c6e"),
                            AuthorId = new Guid("7b863cb7-d866-4322-8e2c-136518f08855"),
                            Description = "Learn Python - the most popular programming language and for Data Science and Software Development",
                            Title = "Python for Data Science, AI & Development"
                        });
                });

            modelBuilder.Entity("CourseStore.API.Entities.Course", b =>
                {
                    b.HasOne("CourseStore.API.Entities.Author", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("CourseStore.API.Entities.Author", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
