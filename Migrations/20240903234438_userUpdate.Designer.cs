﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bangazon_be.Migrations
{
    [DbContext(typeof(BangazonBeDbContext))]
    [Migration("20240903234438_userUpdate")]
    partial class userUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("bangazon_be.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Home Goods"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Health"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Plants"
                        });
                });

            modelBuilder.Entity("bangazon_be.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("PaymentType")
                        .HasColumnType("text");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompletionDate = new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 3,
                            PaymentType = "Paypal",
                            TotalCost = 51.24m
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            TotalCost = 0m
                        });
                });

            modelBuilder.Entity("bangazon_be.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PriceAtSale")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<bool>("Shipped")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            PriceAtSale = 7.04m,
                            ProductId = 2,
                            Shipped = true
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            PriceAtSale = 7.04m,
                            ProductId = 2,
                            Shipped = true
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 1,
                            PriceAtSale = 37.16m,
                            ProductId = 3,
                            Shipped = true
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 2,
                            PriceAtSale = 0.00m,
                            ProductId = 4,
                            Shipped = false
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 2,
                            PriceAtSale = 0.00m,
                            ProductId = 3,
                            Shipped = false
                        });
                });

            modelBuilder.Entity("bangazon_be.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "For those sunny Thanksgiving picnics",
                            Price = 14.70m,
                            Quantity = 16,
                            SellerId = 4,
                            Title = "Solar Turkey Chopper"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            Description = "50% cotton-polyester blend, 45% rayon-styrene blend, 4% elastic, 1% braided titanium",
                            Price = 7.04m,
                            Quantity = 76,
                            SellerId = 4,
                            Title = "Heathered Mindfulness Ankle Socks (1-pair)"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Zany pet detective Ace Ventura (Jim Carrey) looks investigates a missing mascot.",
                            Price = 37.16m,
                            Quantity = 4,
                            SellerId = 4,
                            Title = "Ace Ventura: Pet Detective (1994) DVD"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Very good soft",
                            Price = 59.87m,
                            Quantity = 2530,
                            SellerId = 4,
                            Title = "18-pack Clean-x Facial Tissue"
                        });
                });

            modelBuilder.Entity("bangazon_be.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "423 Friday Ln, Westdale, AL",
                            FirstName = "Steven",
                            LastName = "Murray",
                            Uid = "76FJhdpekly73k7K",
                            Username = "cspan_warrior"
                        },
                        new
                        {
                            Id = 2,
                            Address = "17324 Chamomile Dr, Harley Falls, VT",
                            FirstName = "Hailey",
                            LastName = "Finnegan",
                            Uid = "RplI9hf723kvcZZs",
                            Username = "darkwingduck133"
                        },
                        new
                        {
                            Id = 3,
                            Address = "2413 Main St, Finley, AZ",
                            FirstName = "Cassie",
                            LastName = "Thomas",
                            Uid = "hhfYm734hN1mdifE",
                            Username = "albionblonde"
                        },
                        new
                        {
                            Id = 4,
                            Address = "9230 Christiansen Pk, Sharpsville, MD",
                            FirstName = "Atticus",
                            LastName = "Parker",
                            Uid = "muIE7340mEE223Id",
                            Username = "atticusparker"
                        });
                });

            modelBuilder.Entity("bangazon_be.Models.Order", b =>
                {
                    b.HasOne("bangazon_be.Models.User", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("bangazon_be.Models.OrderProduct", b =>
                {
                    b.HasOne("bangazon_be.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bangazon_be.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("bangazon_be.Models.Product", b =>
                {
                    b.HasOne("bangazon_be.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bangazon_be.Models.User", "Seller")
                        .WithMany("Products")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("bangazon_be.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("bangazon_be.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("bangazon_be.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
