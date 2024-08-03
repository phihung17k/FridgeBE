using FridgeBE.Core.Entities;
using FridgeBE.Core.Enums;

namespace FridgeBE.Infrastructure.Data.DataSeeding
{
    public class CategorySeeding
    {
        public static IEnumerable<Category> SeedCategories()
        {
            CategoryEnum[] categories = Enum.GetValues<CategoryEnum>();
            string now = DateTimeOffset.Now.ToString("HH:mm:ss dd-MM-yyyy");
            for (int i = 1; i < categories.Length; i++)
            {
                yield return new Category
                {
                    Id = i,
                    Name = categories[i].ToString(),
                    CreateBy = now,
                };
            }
        }
    }
}