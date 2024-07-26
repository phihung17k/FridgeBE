using FridgeBE.Core.Entities;

namespace FridgeBE.Infrastructure.Data.DataSeeding
{
    public class CategorySeeding
    {
        public static List<Category> SeedCategories()
        {
            int i = 1;
            var list = new List<Category>
            {
                new Category
                {
                    Id = i++,
                    Name = "Fruit"
                },
                new Category
                {
                    Id = i++,
                    Name = "Nut"
                },
                new Category
                {
                    Id = i++,
                    Name = "Milk"
                },
                new Category
                {
                    Id = i++,
                    Name = "Spice"
                },
                new Category
                {
                    Id = i++,
                    Name = "Meat"
                },
                new Category
                {
                    Id = i++,
                    Name = "Vegetable"
                },
                new Category
                {
                    Id = i++,
                    Name = "Rice",
                    Description = "Product from rice"
                }
            };

            return list;
        }
    }
}