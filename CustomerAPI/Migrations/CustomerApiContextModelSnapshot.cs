﻿// <auto-generated />
using System;
using CustomerService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerService.API.Migrations
{
    [DbContext(typeof(CustomerApiContext))]
    partial class CustomerApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerService.Domain.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Address = "Address1",
                            Email = "cust1@sendeo.com",
                            LastName = "Doe",
                            Name = "John",
                            Phone = "1234567"
                        },
                        new
                        {
                            Id = "2",
                            Address = "Address1",
                            Email = "lebron@sendeo.com",
                            LastName = "James",
                            Name = "Lebron",
                            Phone = "1234567"
                        },
                        new
                        {
                            Id = "3",
                            Address = "Address1",
                            Email = "cagatay@sendeo.com",
                            LastName = "ÇELİK",
                            Name = "Çağatay",
                            Phone = "1234567"
                        });
                });

            modelBuilder.Entity("OrderService.Domain.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            CustomerId = "1",
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = "1"
                        },
                        new
                        {
                            Id = "2",
                            CustomerId = "2",
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = "2"
                        },
                        new
                        {
                            Id = "3",
                            CustomerId = "3",
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = "3"
                        });
                });

            modelBuilder.Entity("ProductService.Domain.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Category = "Category1",
                            Description = "Desc1",
                            ImageFile = "null",
                            Name = "Product1",
                            Price = 10m,
                            Stock = 2
                        },
                        new
                        {
                            Id = "2",
                            Category = "Category1",
                            Description = "Desc2",
                            ImageFile = "null",
                            Name = "Product2",
                            Price = 20m,
                            Stock = 1
                        },
                        new
                        {
                            Id = "3",
                            Category = "Category2",
                            Description = "Desc3",
                            ImageFile = "null",
                            Name = "Product3",
                            Price = 100m,
                            Stock = 2
                        });
                });

            modelBuilder.Entity("OrderService.Domain.Order", b =>
                {
                    b.HasOne("CustomerService.Domain.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductService.Domain.Product", b =>
                {
                    b.HasOne("OrderService.Domain.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("CustomerService.Domain.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OrderService.Domain.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
