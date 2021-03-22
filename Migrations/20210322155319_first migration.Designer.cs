﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectBackendDevelopment.DataContext;

namespace ProjectBackendDevelopment.Migrations
{
    [DbContext(typeof(SponsorContext))]
    [Migration("20210322155319_first migration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("ProjectBackendDevelopment.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            Age = 19,
                            FirstName = "Ewoud",
                            LastName = "De Preester"
                        },
                        new
                        {
                            PlayerId = 2,
                            Age = 19,
                            FirstName = "Alec",
                            LastName = "Hantson"
                        },
                        new
                        {
                            PlayerId = 3,
                            Age = 13,
                            FirstName = "Jarno",
                            LastName = "Vanden Haesevelde"
                        },
                        new
                        {
                            PlayerId = 4,
                            Age = 19,
                            FirstName = "Lara",
                            LastName = "Desmet"
                        });
                });

            modelBuilder.Entity("ProjectBackendDevelopment.Models.Sponsor", b =>
                {
                    b.Property<Guid>("SponsorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("SponsorId");

                    b.HasIndex("TeamId");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("ProjectBackendDevelopment.Models.SponsorPlayer", b =>
                {
                    b.Property<Guid>("SponsorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("SponsorId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("SponsorPlayers");
                });

            modelBuilder.Entity("ProjectBackendDevelopment.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            City = "Manchester",
                            Country = "England",
                            Name = "Manchester City"
                        },
                        new
                        {
                            TeamId = 2,
                            City = "Barcelona",
                            Country = "Spain",
                            Name = "Barcelona"
                        },
                        new
                        {
                            TeamId = 3,
                            City = "Munchen",
                            Country = "Germany",
                            Name = "Bayern"
                        },
                        new
                        {
                            TeamId = 4,
                            City = "Oudenaarde",
                            Country = "Belgium",
                            Name = "Mater"
                        });
                });

            modelBuilder.Entity("ProjectBackendDevelopment.Models.Sponsor", b =>
                {
                    b.HasOne("ProjectBackendDevelopment.Models.Team", "Team")
                        .WithMany("Sponsors")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ProjectBackendDevelopment.Models.SponsorPlayer", b =>
                {
                    b.HasOne("ProjectBackendDevelopment.Models.Player", "Player")
                        .WithMany("SponsorPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectBackendDevelopment.Models.Sponsor", null)
                        .WithMany("SponsorPlayers")
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ProjectBackendDevelopment.Models.Player", b =>
                {
                    b.Navigation("SponsorPlayers");
                });

            modelBuilder.Entity("ProjectBackendDevelopment.Models.Sponsor", b =>
                {
                    b.Navigation("SponsorPlayers");
                });

            modelBuilder.Entity("ProjectBackendDevelopment.Models.Team", b =>
                {
                    b.Navigation("Sponsors");
                });
#pragma warning restore 612, 618
        }
    }
}