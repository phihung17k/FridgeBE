using FridgeBE.Core.Constants;
using FridgeBE.Core.Entities;
using FridgeBE.Infrastructure.Utils;

namespace FridgeBE.Infrastructure.Data.DataSeeding
{
    public class IngredientSeeding
    {
        public static IEnumerable<Ingredient> SeedIngredients()
        {
            Dictionary<string, List<string>> ingredientDic = FileUtils.ReadIngredientsExcelFile();

            // key: category name, value: list of ingredient names
            int categoryId = 1;
            var now = DateTimeOffset.Now;
            foreach (KeyValuePair<string, List<string>> item in ingredientDic)
            {
                foreach (string ingredientName in item.Value)
                {
                    yield return new Ingredient
                    {
                        Id = Guid.NewGuid(),
                        Name = ingredientName,
                        LocalName = ingredientName,
                        CreateBy = AppConstants.Admin,
                        CreateTime = now,
                        CategoryId = categoryId,
                    };
                }
                categoryId++;
            }
        }
    }
}