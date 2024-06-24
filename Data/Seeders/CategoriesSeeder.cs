using asp.net_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.net_mvc.Data.Seeders
{
    public static class CategoriesSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                        Name = "Sanduíches Artesanal",
                    Description = "Sanduíches",
                },
                new Category
                {
                    Id = 2,
                    Name = "Refrigerante Lata",
                    Description = "Bebidas",
                }
            );
        }
    }
}