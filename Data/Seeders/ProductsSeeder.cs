using asp.net_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.net_mvc.Data.Seeders
{
    public class ProductsSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "X-Bacon",
                    Description = "Pão, bife smash, mussarela, bacon e salada",
                    Price = 12.99m,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Coca Cola lata",
                    Description = "Refrigerante lata 350ml",
                    Price = 4.99m,
                    IsAvailable = true,
                    CategoryId = 2
                }
            );
        }
    }
}