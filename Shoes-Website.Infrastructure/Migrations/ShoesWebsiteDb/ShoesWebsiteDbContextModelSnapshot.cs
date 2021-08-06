﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shoes_Website.Infrastructure.Domain;

namespace Shoes_Website.Infrastructure.Migrations.ShoesWebsiteDb
{
    [DbContext(typeof(ShoesWebsiteDbContext))]
    partial class ShoesWebsiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.CustomerReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalReviewer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("CustomerReviews");
                });

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ProductOptionsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductOptionsId")
                        .IsUnique();

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DefaultPrice")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMenShoes")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Original")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Star")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.ProductOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOptions");
                });

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.CustomerReviews", b =>
                {
                    b.HasOne("Shoes_Website.Domain.Models.ShoesWebsite.Product", "Product")
                        .WithMany("CustomerReviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.Invoice", b =>
                {
                    b.HasOne("Shoes_Website.Domain.Models.ShoesWebsite.ProductOptions", "ProductOptions")
                        .WithOne("Invoice")
                        .HasForeignKey("Shoes_Website.Domain.Models.ShoesWebsite.Invoice", "ProductOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductOptions");
                });

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.ProductOptions", b =>
                {
                    b.HasOne("Shoes_Website.Domain.Models.ShoesWebsite.Product", "Product")
                        .WithMany("ProductOptions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.Product", b =>
                {
                    b.Navigation("CustomerReviews");

                    b.Navigation("ProductOptions");
                });

            modelBuilder.Entity("Shoes_Website.Domain.Models.ShoesWebsite.ProductOptions", b =>
                {
                    b.Navigation("Invoice");
                });
#pragma warning restore 612, 618
        }
    }
}
