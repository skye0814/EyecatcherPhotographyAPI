﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class RepositoryContext : DbContext
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
        DbSet<SystemUser> SystemUsers { get; set; }
        DbSet<TransactionHistory> TransactionHistory { get; set; }

    }
}
