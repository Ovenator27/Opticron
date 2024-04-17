﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Opticron.Data;

#nullable disable

namespace Opticron.Migrations
{
    [DbContext(typeof(OpticronContext))]
    [Migration("20240417121702_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Opticron.Models.NavigationCards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkText")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NavigationCards");
                });

            modelBuilder.Entity("Opticron.Models.ProductCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Opticron.Models.SpecialOffers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("OfferText")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SpecialOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
