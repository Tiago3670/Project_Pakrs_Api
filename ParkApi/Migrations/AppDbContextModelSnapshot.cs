﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParkApi.Data;

#nullable disable

namespace ParkApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ParkApi.model.Favourites", b =>
                {
                    b.Property<int>("ParkId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("ParkApi.model.FeaturesList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Entertainment")
                        .HasColumnType("boolean");

                    b.Property<int>("FeaturesId")
                        .HasColumnType("integer");

                    b.Property<bool?>("Food")
                        .HasColumnType("boolean");

                    b.Property<bool?>("Gym")
                        .HasColumnType("boolean");

                    b.Property<bool?>("PetsAllowed")
                        .HasColumnType("boolean");

                    b.Property<bool?>("Shops")
                        .HasColumnType("boolean");

                    b.Property<bool?>("WiFi")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("FeaturesId")
                        .IsUnique();

                    b.ToTable("FeaturesList");
                });

            modelBuilder.Entity("ParkApi.model.LocationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Coodinates")
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("LocationDetail");
                });

            modelBuilder.Entity("ParkApi.model.Parks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParkDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ParkId")
                        .HasColumnType("integer");

                    b.Property<string>("ParkName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Parks");
                });

            modelBuilder.Entity("ParkApi.model.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ParkApi.model.FeaturesList", b =>
                {
                    b.HasOne("ParkApi.model.Parks", null)
                        .WithOne("Features")
                        .HasForeignKey("ParkApi.model.FeaturesList", "FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkApi.model.LocationDetail", b =>
                {
                    b.HasOne("ParkApi.model.Parks", null)
                        .WithOne("Location")
                        .HasForeignKey("ParkApi.model.LocationDetail", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkApi.model.Parks", b =>
                {
                    b.Navigation("Features");

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
