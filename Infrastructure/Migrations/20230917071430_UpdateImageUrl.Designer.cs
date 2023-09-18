﻿// <auto-generated />
using System;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230917071430_UpdateImageUrl")]
    partial class UpdateImageUrl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.19");

            modelBuilder.Entity("Core.Entities.AppointmentPlace", b =>
                {
                    b.Property<long>("AppointmentPlaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlaceName")
                        .HasColumnType("TEXT");

                    b.HasKey("AppointmentPlaceID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Core.Entities.BillingDetails", b =>
                {
                    b.Property<Guid>("BillingDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("TEXT");

                    b.Property<long?>("AppointmentPlaceID")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("CartID")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("REAL");

                    b.Property<long?>("TransactionHistoryID")
                        .HasColumnType("INTEGER");

                    b.HasKey("BillingDetailsID");

                    b.HasIndex("AppointmentPlaceID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("TransactionHistoryID");

                    b.ToTable("BillingDetails");
                });

            modelBuilder.Entity("Core.Entities.Cart", b =>
                {
                    b.Property<Guid>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BillingDetailsID")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalAmounts")
                        .HasColumnType("REAL");

                    b.HasKey("CartID");

                    b.HasIndex("BillingDetailsID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AspNetUsersId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ContactNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerID");

                    b.HasIndex("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Property<long>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("CartID")
                        .HasColumnType("TEXT");

                    b.Property<string>("FreeText1")
                        .HasColumnType("TEXT");

                    b.Property<string>("FreeText2")
                        .HasColumnType("TEXT");

                    b.Property<string>("FreeText3")
                        .HasColumnType("TEXT");

                    b.Property<string>("FreeText4")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<long?>("ProductCategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductTag")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductCategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1L,
                            FreeText1 = "1 Photographer;Pre Birthday Shoot;Soft Copy;On The Day Event Coverage",
                            Price = 4500.0,
                            ProductCategoryID = 1L,
                            ProductName = "PACKAGE 1 (PHOTO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 2L,
                            FreeText1 = "2 Photographers;Pre Birthday Shoot;Soft Copy;On The Day Event Coverage",
                            Price = 6500.0,
                            ProductCategoryID = 1L,
                            ProductName = "PACKAGE 2 (PHOTO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 3L,
                            FreeText1 = "1 Photographer;1 Videographer;Pre Birthday Shoot;4-5 minutes Video Highlights;Soft Copy;On The Day Event Coverage",
                            Price = 8500.0,
                            ProductCategoryID = 1L,
                            ProductName = "PACKAGE 3 (PHOTO & VIDEO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 4L,
                            FreeText1 = "2 Photographers;1 videographer;Pre Debut or Birthday Shoot;Soft Copy;4-5 minutes Video Highlights;Unlimited Shots Photo Booth (2 hours);20 pages Hardbound Photo Album;Hair and Make Up Artist;On The Day Event Coverage",
                            Price = 22000.0,
                            ProductCategoryID = 1L,
                            ProductName = "ALL IN PACKAGE",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 5L,
                            FreeText1 = "",
                            Price = 3000.0,
                            ProductCategoryID = 2L,
                            ProductName = "PACKAGE 1 (PHOTO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 6L,
                            FreeText1 = "",
                            Price = 5500.0,
                            ProductCategoryID = 2L,
                            ProductName = "PACKAGE 2 (PHOTO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 7L,
                            FreeText1 = "",
                            Price = 7500.0,
                            ProductCategoryID = 2L,
                            ProductName = "PACKAGE 3 (PHOTO & VIDEO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 8L,
                            FreeText1 = "",
                            Price = 5500.0,
                            ProductCategoryID = 2L,
                            ProductName = "PACKAGE 4 (PHOTO+PHOTOBOOTH)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 9L,
                            FreeText1 = "",
                            Price = 6500.0,
                            ProductCategoryID = 3L,
                            ProductName = "PACKAGE A (PHOTO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 10L,
                            FreeText1 = "",
                            Price = 12500.0,
                            ProductCategoryID = 3L,
                            ProductName = "PACKAGE B1 (PHOTO & VIDEO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 11L,
                            FreeText1 = "",
                            Price = 14000.0,
                            ProductCategoryID = 3L,
                            ProductName = "PACKAGE B2 (PHOTO & VIDEO)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 12L,
                            FreeText1 = "",
                            Price = 17000.0,
                            ProductCategoryID = 3L,
                            ProductName = "PACKAGE C1 (PHOTO+VIDEO+ALBUM)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 13L,
                            FreeText1 = "",
                            Price = 18500.0,
                            ProductCategoryID = 3L,
                            ProductName = "PACKAGE C2 (PHOTO+VIDEO+ALBUM)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 14L,
                            FreeText1 = "",
                            Price = 17500.0,
                            ProductCategoryID = 3L,
                            ProductName = "PACKAGE D1 (PHOTO+VIDEO+HMUA)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 15L,
                            FreeText1 = "",
                            Price = 17500.0,
                            ProductCategoryID = 3L,
                            ProductName = "PACKAGE D2 (PHOTO+VIDEO+ALBUM)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 16L,
                            FreeText1 = "",
                            Price = 38000.0,
                            ProductCategoryID = 3L,
                            ProductName = "PACKAGE E (ALL IN)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 17L,
                            FreeText1 = "",
                            Price = 5000.0,
                            ProductCategoryID = 4L,
                            ProductName = "HAIR AND MAKE UP ARTIST A",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 18L,
                            FreeText1 = "",
                            Price = 12000.0,
                            ProductCategoryID = 4L,
                            ProductName = "HAIR AND MAKE UP ARTIST B",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 19L,
                            FreeText1 = "",
                            Price = 500.0,
                            ProductCategoryID = 4L,
                            ProductName = "BRIDESMAIDS HAIR AND MAKE UP",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 20L,
                            FreeText1 = "",
                            Price = 5000.0,
                            ProductCategoryID = 4L,
                            ProductName = "COORDINATOR",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 21L,
                            FreeText1 = "",
                            Price = 5000.0,
                            ProductCategoryID = 4L,
                            ProductName = "SOUNDS AND LIGHTS",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 22L,
                            FreeText1 = "",
                            Price = 5000.0,
                            ProductCategoryID = 4L,
                            ProductName = "EMCEE",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 23L,
                            FreeText1 = "",
                            Price = 4500.0,
                            ProductCategoryID = 4L,
                            ProductName = "40-PAGE PHOTO ALBUM IN HARDBOUND",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 24L,
                            FreeText1 = "",
                            Price = 2500.0,
                            ProductCategoryID = 4L,
                            ProductName = "20-PAGE PHOTO ALBUM IN HARDBOUND",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 25L,
                            FreeText1 = "",
                            Price = 6000.0,
                            ProductCategoryID = 4L,
                            ProductName = "SAME DAY EDIT (SDE EDITOR)",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 26L,
                            FreeText1 = "",
                            Price = 4000.0,
                            ProductCategoryID = 4L,
                            ProductName = "AERIAL DRONE SHOTS",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 27L,
                            FreeText1 = "",
                            Price = 700.0,
                            ProductCategoryID = 4L,
                            ProductName = "FLASH DRIVE",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 28L,
                            FreeText1 = "",
                            Price = 3000.0,
                            ProductCategoryID = 4L,
                            ProductName = "ADDITIONAL PHOTOGRAPHER",
                            ProductTag = ""
                        },
                        new
                        {
                            ProductID = 29L,
                            FreeText1 = "",
                            Price = 4500.0,
                            ProductCategoryID = 4L,
                            ProductName = "ADDITIONAL VIDEOGRAPHER",
                            ProductTag = ""
                        });
                });

            modelBuilder.Entity("Core.Entities.ProductCategory", b =>
                {
                    b.Property<long>("ProductCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductCategoryID");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            ProductCategoryID = 1L,
                            CategoryDescription = "EyeCatch your birthday with wonderful shots",
                            CategoryName = "Birthday Services",
                            ImageUrl = "/images/productcategories/birthday1.jpg"
                        },
                        new
                        {
                            ProductCategoryID = 2L,
                            CategoryDescription = "EyeCatch your beautiful kid of joy",
                            CategoryName = "Christening Services",
                            ImageUrl = "/images/productcategories/christening1.jpg"
                        },
                        new
                        {
                            ProductCategoryID = 3L,
                            CategoryDescription = "EyeCatch your wedding memories with your lifetime partner",
                            CategoryName = "Wedding Services",
                            ImageUrl = "/images/productcategories/wedding1.jpg"
                        },
                        new
                        {
                            ProductCategoryID = 4L,
                            CategoryDescription = "Want to see more? Click here for other EyeCatcher services",
                            CategoryName = "Other Services",
                            ImageUrl = "/images/productcategories/others1.jpg"
                        });
                });

            modelBuilder.Entity("Core.Entities.TransactionHistory", b =>
                {
                    b.Property<long>("TransactionHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionHistoryID");

                    b.HasIndex("CustomerID");

                    b.ToTable("TransactionHistory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                            ConcurrencyStamp = "f138d5d8-c8dd-412f-a53a-34d79242f281",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                            ConcurrencyStamp = "aa54dd14-3502-4607-b3ae-bc8442ccec2c",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.HasData(
                        new
                        {
                            Id = "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b3e48790-180a-4f50-96f5-59b76d7a955d",
                            Email = "skye0814@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SKYE0814@GMAIL.COM",
                            NormalizedUserName = "SKYE0814",
                            PasswordHash = "AQAAAAEAACcQAAAAEBf87/J9vC/vl7wyPg/vkrREx+JAsNt+msyKYQxoxQbEMuoQsLylPQH0wL6zhiOsvw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2d3e6945-e14c-411f-b521-d0b5684cb2ed",
                            TwoFactorEnabled = false,
                            UserName = "skye0814"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Core.Entities.BillingDetails", b =>
                {
                    b.HasOne("Core.Entities.AppointmentPlace", "AppointmentPlace")
                        .WithMany()
                        .HasForeignKey("AppointmentPlaceID");

                    b.HasOne("Core.Entities.Customer", "Customer")
                        .WithMany("BillingDetails")
                        .HasForeignKey("CustomerID");

                    b.HasOne("Core.Entities.TransactionHistory", null)
                        .WithMany("BillingDetails")
                        .HasForeignKey("TransactionHistoryID");

                    b.Navigation("AppointmentPlace");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Core.Entities.Cart", b =>
                {
                    b.HasOne("Core.Entities.BillingDetails", "BillingDetails")
                        .WithMany("Carts")
                        .HasForeignKey("BillingDetailsID");

                    b.Navigation("BillingDetails");
                });

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", "AspNetUsers")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AspNetUsers");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.HasOne("Core.Entities.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartID");

                    b.HasOne("Core.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryID");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Core.Entities.TransactionHistory", b =>
                {
                    b.HasOne("Core.Entities.Customer", "Customer")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("CustomerID");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.BillingDetails", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("Core.Entities.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.Navigation("BillingDetails");

                    b.Navigation("TransactionHistories");
                });

            modelBuilder.Entity("Core.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Core.Entities.TransactionHistory", b =>
                {
                    b.Navigation("BillingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
