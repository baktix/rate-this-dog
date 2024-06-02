﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RateThisDog.Data;

#nullable disable

namespace RateThisDog.Data.Migrations
{
    [DbContext(typeof(DogDbContext))]
    [Migration("20240531205256_Initial build")]
    partial class Initialbuild
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("RateThisDog.Data.Dog", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("RateThisDog.Data.UserRating", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DogID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Rating")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("DogID");

                    b.ToTable("UserRatings");
                });

            modelBuilder.Entity("RateThisDog.Data.UserRating", b =>
                {
                    b.HasOne("RateThisDog.Data.Dog", null)
                        .WithMany("UserRatings")
                        .HasForeignKey("DogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RateThisDog.Data.Dog", b =>
                {
                    b.Navigation("UserRatings");
                });
#pragma warning restore 612, 618
        }
    }
}