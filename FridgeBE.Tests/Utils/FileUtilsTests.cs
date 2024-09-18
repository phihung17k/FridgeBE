using FridgeBE.Infrastructure.Utils;

namespace FridgeBE.Tests.Utils
{
    public class FileUtilsTests
    {
        [Fact]
        public void ReadExcelFile()
        {
            var result = FileUtils.ReadIngredientsExcelFile();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}