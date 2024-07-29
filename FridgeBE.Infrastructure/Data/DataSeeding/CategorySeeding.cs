using FridgeBE.Core.Entities;
using FridgeBE.Core.Enums;

namespace FridgeBE.Infrastructure.Data.DataSeeding
{
    public class CategorySeeding
    {
        public static List<Category> SeedCategories()
        {
            CategoryEnum[] categories = Enum.GetValues<CategoryEnum>();
            for (int i = 1; i < categories.Length; i++)
            {
                //yield new Category
                //{
                    
                //}
            }
        }
    }
}