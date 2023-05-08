using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Quantity> Quantities { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Warehouse>()
                .HasOne(a => a.Price).WithOne(b => b.Warehouse)
                .HasForeignKey<Price>(e => e.WarehouseRef);
            builder.Entity<Warehouse>()
                .HasOne(a => a.Quantity).WithOne(b => b.Warehouse)
                .HasForeignKey<Quantity>(e => e.WarehouseRef);
            builder.Entity<ItemCategory>()
                .HasKey(ic=> new {ic.ItemId,ic.CategoryId});
            builder.Entity<ItemCategory>()
                .HasOne<Item>(ic => ic.Item)
                .WithMany(i => i.ItemCategory)
                .HasForeignKey(ic => ic.ItemId);
            builder.Entity<ItemCategory>()
                .HasOne<Category>(ic => ic.Category)
                .WithMany(i => i.ItemCategory)
                .HasForeignKey(ic => ic.CategoryId);
        }

    }
}
