using FridgeBE.Core.Entities;
using FridgeBE.Infrastructure.Data.DataSeeding;

namespace FridgeBE.Tests.Data
{
    public class CategorySeedingTests
    {
        [Fact]
        public void SeedCategoryTests()
        {
            IEnumerable<Category> categories = CategorySeeding.SeedCategories();

            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
            Assert.Equal(18, categories.Count());
        }
    }
}