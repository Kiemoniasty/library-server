﻿// <auto-generated />
using System;
using Library_WebServer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library_WebServer.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library_WebServer.Models.Database.AuthorDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.CommentDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<Guid>("LibraryPublication.Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LibraryUser.Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LibraryPublication.Id");

                    b.HasIndex("LibraryUser.Id");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.PublicationDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LibraryAuthor.Id")
                        .HasColumnType("uuid");

                    b.Property<int>("LibraryObjectGenre.Id")
                        .HasColumnType("integer");

                    b.Property<int>("LibraryObjectStatus.Id")
                        .HasColumnType("integer");

                    b.Property<int>("LibraryObjectType.Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "Name");

                    b.HasKey("Id");

                    b.HasIndex("LibraryAuthor.Id");

                    b.HasIndex("LibraryObjectGenre.Id");

                    b.HasIndex("LibraryObjectStatus.Id");

                    b.HasIndex("LibraryObjectType.Id");

                    b.ToTable("Publications", (string)null);
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.PublicationGenreDbModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 1,
                            Name = "ScienceFiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cooking"
                        });
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.PublicationStatusDbModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Statuses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "Available"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Reserved"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Unavailable"
                        });
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.PublicationTypeDbModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("PublicationTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "Book"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Magazine"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Newspaper"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ScientificPaper"
                        });
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.ReservationDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LibraryPublication.Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LibraryUser.Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LibraryPublication.Id");

                    b.HasIndex("LibraryUser.Id");

                    b.ToTable("Reservations", (string)null);
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.UserAccountTypeDbModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "User"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Librarian"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.UserDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserAccountType.Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountType.Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.CommentDbModel", b =>
                {
                    b.HasOne("Library_WebServer.Models.Database.PublicationDbModel", "LibraryPublication")
                        .WithMany()
                        .HasForeignKey("LibraryPublication.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_WebServer.Models.Database.UserDbModel", "LibraryUser")
                        .WithMany()
                        .HasForeignKey("LibraryUser.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LibraryPublication");

                    b.Navigation("LibraryUser");
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.PublicationDbModel", b =>
                {
                    b.HasOne("Library_WebServer.Models.Database.AuthorDbModel", "LibraryAuthor")
                        .WithMany()
                        .HasForeignKey("LibraryAuthor.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_WebServer.Models.Database.PublicationGenreDbModel", "LibraryObjectGenre")
                        .WithMany()
                        .HasForeignKey("LibraryObjectGenre.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_WebServer.Models.Database.PublicationStatusDbModel", "LibraryObjectStatus")
                        .WithMany()
                        .HasForeignKey("LibraryObjectStatus.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_WebServer.Models.Database.PublicationTypeDbModel", "LibraryObjectType")
                        .WithMany()
                        .HasForeignKey("LibraryObjectType.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LibraryAuthor");

                    b.Navigation("LibraryObjectGenre");

                    b.Navigation("LibraryObjectStatus");

                    b.Navigation("LibraryObjectType");
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.ReservationDbModel", b =>
                {
                    b.HasOne("Library_WebServer.Models.Database.PublicationDbModel", "LibraryPublication")
                        .WithMany("LibraryReservations")
                        .HasForeignKey("LibraryPublication.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_WebServer.Models.Database.UserDbModel", "LibraryUser")
                        .WithMany()
                        .HasForeignKey("LibraryUser.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LibraryPublication");

                    b.Navigation("LibraryUser");
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.UserDbModel", b =>
                {
                    b.HasOne("Library_WebServer.Models.Database.UserAccountTypeDbModel", "UserAccountType")
                        .WithMany()
                        .HasForeignKey("UserAccountType.Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccountType");
                });

            modelBuilder.Entity("Library_WebServer.Models.Database.PublicationDbModel", b =>
                {
                    b.Navigation("LibraryReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
