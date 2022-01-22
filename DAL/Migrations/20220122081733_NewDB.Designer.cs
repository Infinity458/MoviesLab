﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20220122081733_NewDB")]
    partial class NewDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<int>("ActorsId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("ActorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("MovieActors");
                });

            modelBuilder.Entity("Domain.Enities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birth")
                        .HasMaxLength(15)
                        .HasColumnType("datetime2");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("GenderId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Domain.Enities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Domain.Enities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Enities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birth")
                        .HasMaxLength(15)
                        .HasColumnType("datetime2");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Domain.Enities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Domain.Enities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Domain.Enities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int?>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProductionCompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("ProductionCompanyId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Domain.Enities.ProductionCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProductionCompanies");
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("Domain.Enities.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Enities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Enities.Actor", b =>
                {
                    b.HasOne("Domain.Enities.City", "City")
                        .WithMany("Actors")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Enities.Gender", "Gender")
                        .WithMany("Actors")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Domain.Enities.City", b =>
                {
                    b.HasOne("Domain.Enities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Enities.Director", b =>
                {
                    b.HasOne("Domain.Enities.Gender", "Gender")
                        .WithMany("Directors")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Domain.Enities.Movie", b =>
                {
                    b.HasOne("Domain.Enities.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Enities.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Enities.ProductionCompany", "ProductionCompany")
                        .WithMany("Movies")
                        .HasForeignKey("ProductionCompanyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Director");

                    b.Navigation("Genre");

                    b.Navigation("ProductionCompany");
                });

            modelBuilder.Entity("Domain.Enities.City", b =>
                {
                    b.Navigation("Actors");
                });

            modelBuilder.Entity("Domain.Enities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Enities.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Domain.Enities.Gender", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Directors");
                });

            modelBuilder.Entity("Domain.Enities.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Domain.Enities.ProductionCompany", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
