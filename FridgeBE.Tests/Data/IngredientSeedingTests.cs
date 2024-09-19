using FridgeBE.Core.Entities;
using FridgeBE.Infrastructure.Data.DataSeeding;

namespace FridgeBE.Tests.Data
{
    public class IngredientSeedingTests
    {
        [Fact]
        public void SeedIngredientsTest()
        {
            IEnumerable<Ingredient> ingredients = IngredientSeeding.SeedIngredients();

            Assert.NotEmpty(ingredients);
        }
    }
}