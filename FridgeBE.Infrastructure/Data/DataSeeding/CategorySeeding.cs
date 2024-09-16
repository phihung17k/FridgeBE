using FridgeBE.Core.Entities;

namespace FridgeBE.Infrastructure.Data.DataSeeding
{
    public class CategorySeeding
    {
        public static IEnumerable<Category> SeedCategories()
        {
            //CategoryEnum[] categories = Enum.GetValues<CategoryEnum>();
            //var now = DateTimeOffset.Now;
            //for (int i = 1; i < categories.Length; i++)
            //{
            //    yield return new Category
            //    {
            //        Id = i,
            //        Name = categories[i].ToString(),
            //        CreateTime = now,
            //        CreateBy = "admin"
            //    };
            //}

            return CategoryStorage.GetAllCategories().Values;
        }
    }
}