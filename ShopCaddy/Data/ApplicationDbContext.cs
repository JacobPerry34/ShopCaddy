using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopCaddy.Models;

namespace ShopCaddy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PurchaseOrder>().HasMany(purchaseOrder => purchaseOrder.PurchaseOrderProducts)
                             .WithOne(purchaseOrderProducts => purchaseOrderProducts.PurchaseOrder)
                             .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<PurchaseOrderProduct>().HasMany(purchaseOrderProduct => purchaseOrderProduct.Products)
            //                   .WithOne(Products => Products.PurchaseOr)
            //                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
