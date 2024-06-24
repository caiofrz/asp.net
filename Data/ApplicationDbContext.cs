using asp.net_mvc.Data.Seeders;
using asp.net_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.net_mvc.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CategoriesSeeder.Seed(modelBuilder);
        ProductsSeeder.Seed(modelBuilder);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
