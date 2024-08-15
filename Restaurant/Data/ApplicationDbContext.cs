﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<Ingredient>? Ingredients { get; set; }
        public DbSet<ProductIngredient>? ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductIngredient>()
           .HasKey(x => new { x.ProductId, x.IngredientId });

            builder.Entity<ProductIngredient>()
                .HasOne(x => x.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<ProductIngredient>()
                .HasOne(x => x.Ingredient)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(x => x.IngredientId);
        }
    }
}
