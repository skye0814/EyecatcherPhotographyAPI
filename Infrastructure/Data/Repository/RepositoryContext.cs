using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class RepositoryContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<AppointmentPlace> Appointments { get; set; }
        DbSet<BillingDetails> BillingDetails { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<TransactionHistory> TransactionHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BillingDetails>(p =>
            {
                p.HasKey(x => x.BillingDetailsID);

                p.HasOne(x => x.Customer)
                    .WithMany(x => x.BillingDetails)
                    .HasForeignKey(x => x.CustomerID)
                    .HasPrincipalKey(x => x.CustomerID);

                p.HasMany(x => x.Carts)
                   .WithOne(x => x.BillingDetails)
                   .HasForeignKey(x => x.BillingDetailsID);
            });

            modelBuilder.Entity<Customer>(p =>
            {
                p.HasKey(x => x.CustomerID);

                p.HasMany(x => x.TransactionHistories)
                    .WithOne(x => x.Customer)
                    .HasForeignKey(x => x.CustomerID)
                    .HasPrincipalKey(x => x.CustomerID);

                p.HasOne(x => x.AspNetUsers);
            });

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser
            {
                Id = "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                UserName = "skye0814",
                NormalizedUserName = "SKYE0814",
                Email = "skye0814@gmail.com",
                NormalizedEmail = "SKYE0814@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "@Skye0814!") 
            };
            modelBuilder.Entity<IdentityUser>().HasData(user);

            
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "6ed57acf-cb38-4df4-ac5f-be45115fd783", Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole { Id = "38b13138-2eb6-415b-b1d4-c36f6c6fdee4", Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryID = 1, CategoryName = "Birthday Services", CategoryDescription = "EyeCatch your birthday with wonderful shots", ImageUrl = "https://localhost:7081/images/productcategories/birthday1.jpg" },
                new ProductCategory { ProductCategoryID = 2, CategoryName = "Christening Services", CategoryDescription = "EyeCatch your beautiful kid of joy", ImageUrl = "https://localhost:7081/images/productcategories/christening1.jpg" },
                new ProductCategory { ProductCategoryID = 3, CategoryName = "Wedding Services", CategoryDescription = "EyeCatch your wedding memories with your lifetime partner", ImageUrl = "https://localhost:7081/images/productcategories/wedding1.jpg" },
                new ProductCategory { ProductCategoryID = 4, CategoryName = "Other Services", CategoryDescription = "Want to see more? Click here for other EyeCatcher services", ImageUrl = "https://localhost:7081/images/productcategories/others1.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
                // Birthday Services (1)
                new Product { ProductID = 1, ProductName = "PACKAGE 1 (PHOTO)", ProductTag = "", Price = 4500.00, ProductCategoryID = 1, FreeText1 = "1 Photographer;Pre Birthday Shoot;Soft Copy;On The Day Event Coverage" },
                new Product { ProductID = 2, ProductName = "PACKAGE 2 (PHOTO)", ProductTag = "", Price = 6500.00, ProductCategoryID = 1, FreeText1 = "2 Photographers;Pre Birthday Shoot;Soft Copy;On The Day Event Coverage" },
                new Product { ProductID = 3, ProductName = "PACKAGE 3 (PHOTO & VIDEO)", ProductTag = "", Price = 8500.00, ProductCategoryID = 1, FreeText1 = "1 Photographer;1 Videographer;Pre Birthday Shoot;4-5 minutes Video Highlights;Soft Copy;On The Day Event Coverage" },
                new Product { ProductID = 4, ProductName = "ALL IN PACKAGE", ProductTag = "", Price = 22000.00, ProductCategoryID = 1, FreeText1 = "2 Photographers;1 videographer;Pre Debut or Birthday Shoot;Soft Copy;4-5 minutes Video Highlights;Unlimited Shots Photo Booth (2 hours);20 pages Hardbound Photo Album;Hair and Make Up Artist;On The Day Event Coverage" },

                // Christening Services (2)
                new Product { ProductID = 5, ProductName = "PACKAGE 1 (PHOTO)", ProductTag = "", Price = 3000.00, ProductCategoryID = 2, FreeText1 = "" },
                new Product { ProductID = 6, ProductName = "PACKAGE 2 (PHOTO)", ProductTag = "", Price = 5500.00, ProductCategoryID = 2, FreeText1 = "" },
                new Product { ProductID = 7, ProductName = "PACKAGE 3 (PHOTO & VIDEO)", ProductTag = "", Price = 7500.00, ProductCategoryID = 2, FreeText1 = "" },
                new Product { ProductID = 8, ProductName = "PACKAGE 4 (PHOTO+PHOTOBOOTH)", ProductTag = "", Price = 5500.00, ProductCategoryID = 2, FreeText1 = "" },

                // Wedding Services (3)
                new Product { ProductID = 9, ProductName = "PACKAGE A (PHOTO)", ProductTag = "", Price = 6500.00, ProductCategoryID = 3, FreeText1 = "" },
                new Product { ProductID = 10, ProductName = "PACKAGE B1 (PHOTO & VIDEO)", ProductTag = "", Price = 12500.00, ProductCategoryID = 3, FreeText1 = "" },
                new Product { ProductID = 11, ProductName = "PACKAGE B2 (PHOTO & VIDEO)", ProductTag = "", Price = 14000.00, ProductCategoryID = 3, FreeText1 = "" },
                new Product { ProductID = 12, ProductName = "PACKAGE C1 (PHOTO+VIDEO+ALBUM)", ProductTag = "", Price = 17000.00, ProductCategoryID = 3, FreeText1 = "" },
                new Product { ProductID = 13, ProductName = "PACKAGE C2 (PHOTO+VIDEO+ALBUM)", ProductTag = "", Price = 18500.00, ProductCategoryID = 3, FreeText1 = "" },
                new Product { ProductID = 14, ProductName = "PACKAGE D1 (PHOTO+VIDEO+HMUA)", ProductTag = "", Price = 17500.00, ProductCategoryID = 3, FreeText1 = "" },
                new Product { ProductID = 15, ProductName = "PACKAGE D2 (PHOTO+VIDEO+ALBUM)", ProductTag = "", Price = 17500.00, ProductCategoryID = 3, FreeText1 = "" },
                new Product { ProductID = 16, ProductName = "PACKAGE E (ALL IN)", ProductTag = "", Price = 38000.00, ProductCategoryID = 3, FreeText1 = "" },

                // Other Services (4)
                new Product { ProductID = 17, ProductName = "HAIR AND MAKE UP ARTIST A", ProductTag = "", Price = 5000.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 18, ProductName = "HAIR AND MAKE UP ARTIST B", ProductTag = "", Price = 12000.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 19, ProductName = "BRIDESMAIDS HAIR AND MAKE UP", ProductTag = "", Price = 500.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 20, ProductName = "COORDINATOR", ProductTag = "", Price = 5000.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 21, ProductName = "SOUNDS AND LIGHTS", ProductTag = "", Price = 5000.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 22, ProductName = "EMCEE", ProductTag = "", Price = 5000.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 23, ProductName = "40-PAGE PHOTO ALBUM IN HARDBOUND", ProductTag = "", Price = 4500.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 24, ProductName = "20-PAGE PHOTO ALBUM IN HARDBOUND", ProductTag = "", Price = 2500.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 25, ProductName = "SAME DAY EDIT (SDE EDITOR)", ProductTag = "", Price = 6000.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 26, ProductName = "AERIAL DRONE SHOTS", ProductTag = "", Price = 4000.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 27, ProductName = "FLASH DRIVE", ProductTag = "", Price = 700, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 28, ProductName = "ADDITIONAL PHOTOGRAPHER", ProductTag = "", Price = 3000.00, ProductCategoryID = 4, FreeText1 = "" },
                new Product { ProductID = 29, ProductName = "ADDITIONAL VIDEOGRAPHER", ProductTag = "", Price = 4500.00, ProductCategoryID = 4, FreeText1 = "" }
            );
        }

    }
}
