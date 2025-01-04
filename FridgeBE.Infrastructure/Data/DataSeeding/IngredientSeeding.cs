using FridgeBE.Core.Constants;
using FridgeBE.Core.Entities;
using FridgeBE.Infrastructure.Utils;
using Microsoft.IdentityModel.Tokens;

namespace FridgeBE.Infrastructure.Data.DataSeeding
{
    public class IngredientSeeding
    {
        public static IEnumerable<Ingredient> SeedIngredients()
        {
            Dictionary<string, List<Tuple<string, string>>> ingredientDic = FileUtils.ReadIngredientsExcelFile();

            // key: category name, value: list of ingredient names
            int categoryId = 1;
            var now = DateTimeOffset.Now;
            foreach (KeyValuePair<string, List<Tuple<string, string>>> item in ingredientDic)
            {
                // string1: name. string2: description
                foreach (Tuple<string, string> info in item.Value)
                {
                    yield return new Ingredient
                    {
                        Id = Guid.NewGuid(),
                        Name = info.Item1,
                        LocalName = info.Item1,
                        Description = info.Item2,
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