using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;

namespace PointOfSale;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source = products.db");
}