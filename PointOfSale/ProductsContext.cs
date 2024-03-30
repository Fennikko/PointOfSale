using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;

namespace PointOfSale;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source = products.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(o => o.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(o => o.ProductId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(o => o.Products)
            .HasForeignKey(p => p.CategoryId);


        modelBuilder.Entity<Category>()
            .HasData(new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Produce"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Meat"
                }
            });

        modelBuilder.Entity<Product>()
            .HasData(new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Potatoes",
                    Price = .99m
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 2,
                    Name = "Steak",
                    Price = 12.99m
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 1,
                    Name = "Apples",
                    Price = 1.29m
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    Name = "Pork Chops",
                    Price = 10.99m
                }

            });
    }
}