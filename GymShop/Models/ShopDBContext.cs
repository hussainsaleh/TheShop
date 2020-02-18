using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymShop.Models
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Using Fluent API in this case is not a necessary step since I have followed the convensions of EF core.
            // This effort was only made to ease maintenance.
            modelBuilder.Entity<Customer>()
                .HasMany<SaleOrder>(s => s.SaleOrders)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            // Not necessary since this relationship is established by convention and by the above configuration.
            modelBuilder.Entity<SaleOrder>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(s => s.SaleOrders)
                .HasForeignKey(c => c.CustomerId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductSale>()
                .HasOne<SaleOrder>(so => so.SaleOrder)
                .WithMany(ps => ps.ProductSales)
                .HasForeignKey(ps => ps.SaleOrderId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductSale>()
                .HasOne<Product>(p => p.Product)
                .WithMany(ps => ps.ProductSales)
                .HasForeignKey(p => p.ProductId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuring the conposite primary key for the joining entity ProductSupplier.
            modelBuilder.Entity<ProductSupplier>()
                .HasKey(ps => new { ps.ProductId, ps.SupplierId });

            modelBuilder.Entity<ProductSupplier>()
                .HasOne<Product>(p => p.Product)
                .WithMany(ps => ps.ProductSuppliers)
                .HasForeignKey(ps => ps.ProductId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne<Supplier>(s => s.Supplier)
                .WithMany(ps => ps.ProductSuppliers)
                .HasForeignKey(ps => ps.SupplierId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Not necessary since this relationship is established by convention and by the above configuration.
            modelBuilder.Entity<Supplier>()
                .HasMany<ProductSupplier>(ps => ps.ProductSuppliers)
                .WithOne(s => s.Supplier)
                .HasForeignKey(ps => ps.SupplierId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Chocolate",
                    Size = 500,
                    MassUnit = Enums.MassUnit.g,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Chocolate",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Chocolate",
                    Size = 2.5,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Chocolate",
                    Size = 5,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Vanilla",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Vanilla",
                    Size = 500,
                    MassUnit = Enums.MassUnit.g,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Vanilla",
                    Size = 5,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Strawberry",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Strawberry",
                    Size = 2.5,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Strawberry",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Unflavoured",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Unflavoured",
                    Size = 500,
                    MassUnit = Enums.MassUnit.g,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Chocolate",
                    Size = 500,
                    MassUnit = Enums.MassUnit.g,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Impact Whey Protein",
                    Flavour = "Chocolate",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Premium whey packed with 21g of protein per serving, for the everyday protein you need from a quality source.",
                    Price = 12
                },
                new Product
                {
                    Name = "Pure Whey Protein",
                    Flavour = "Chocolate",
                    Size = 2.5,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "It is a premium quality whey protein powder, purchased directly from a European dairy, using grass-fed cow’s milk, and contains a massive 80% Whey Protein.",
                    Price = 12
                },
                new Product
                {
                    Name = "Pure Whey Protein",
                    Flavour = "Vanilla",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "It is a premium quality whey protein powder, purchased directly from a European dairy, using grass-fed cow’s milk, and contains a massive 80% Whey Protein.",
                    Price = 12
                },
                new Product
                {
                    Name = "Pure Whey Protein",
                    Flavour = "Vanilla",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "It is a premium quality whey protein powder, purchased directly from a European dairy, using grass-fed cow’s milk, and contains a massive 80% Whey Protein.",
                    Price = 12
                },
                new Product
                {
                    Name = "Pure Whey Protein",
                    Flavour = "Strawberry",
                    Size = 500,
                    MassUnit = Enums.MassUnit.g,
                    Description = "It is a premium quality whey protein powder, purchased directly from a European dairy, using grass-fed cow’s milk, and contains a massive 80% Whey Protein.",
                    Price = 12
                },
                new Product
                {
                    Name = "Pure Whey Protein",
                    Flavour = "Strawberry",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "It is a premium quality whey protein powder, purchased directly from a European dairy, using grass-fed cow’s milk, and contains a massive 80% Whey Protein.",
                    Price = 12
                },
                new Product
                {
                    Name = "Pure Whey Protein",
                    Flavour = "Strawberry",
                    Size = 2.5,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "It is a premium quality whey protein powder, purchased directly from a European dairy, using grass-fed cow’s milk, and contains a massive 80% Whey Protein.",
                    Price = 12
                },
                new Product
                {
                    Name = "Pure Whey Protein",
                    Flavour = "Strawberry",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "It is a premium quality whey protein powder, purchased directly from a European dairy, using grass-fed cow’s milk, and contains a massive 80% Whey Protein.",
                    Price = 12
                },
                new Product
                {
                    Name = "Diet Whey Protein",
                    Flavour = "Strawberry",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Diet Whey is a high protein, low carb, low calorie protein shake that assists fat loss.",
                    Price = 12
                },
                new Product
                {
                    Name = "Diet Whey Protein",
                    Flavour = "Vanilla",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Diet Whey is a high protein, low carb, low calorie protein shake that assists fat loss.",
                    Price = 12
                },
                new Product
                {
                    Name = "Diet Whey Protein",
                    Flavour = "Chocolate",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Diet Whey is a high protein, low carb, low calorie protein shake that assists fat loss.",
                    Price = 12
                },
                new Product
                {
                    Name = "Diet Whey Protein",
                    Flavour = "Unfalvoured",
                    Size = 1,
                    MassUnit = Enums.MassUnit.kg,
                    Description = "Diet Whey is a high protein, low carb, low calorie protein shake that assists fat loss.",
                    Price = 12
                },
                new Product
                {
                    Name = "Diet Whey Protein",
                    Flavour = "Strawberry",
                    Size = 500,
                    MassUnit = Enums.MassUnit.g,
                    Description = "Diet Whey is a high protein, low carb, low calorie protein shake that assists fat loss.",
                    Price = 12
                }
                );
        }
    }
}
