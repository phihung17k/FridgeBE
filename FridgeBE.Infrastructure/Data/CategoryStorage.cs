using FridgeBE.Core.Constants;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Enums;
using System.ComponentModel;
using System.Reflection;

namespace FridgeBE.Infrastructure.Data
{
    public static class CategoryStorage
    {
        private static Dictionary<int, Category> _categories = [];
        private static readonly Dictionary<CategoryEnum, string> _categoryLocalNames = new()
        {
            { CategoryEnum.Unknown, "Unknown" },
            { CategoryEnum.Cereals, "Ngũ cốc" },
            { CategoryEnum.RootsTubersPlantains, "Khoai củ" },
            { CategoryEnum.Legumes, "Đậu" },
            { CategoryEnum.Vegetables, "Rau quả" },
            { CategoryEnum.Fruits, "Trái cây" },
            { CategoryEnum.SeedsNuts, "Hạt" },
            { CategoryEnum.Meat, "Thịt" },
            { CategoryEnum.InsectsGrubs, "Côn trùng và sâu bọ" },
            { CategoryEnum.FishShellfish, "Thủy sản" },
            { CategoryEnum.Eggs, "Trứng" },
            { CategoryEnum.MilkDairy, "Sữa" },
            { CategoryEnum.Snacks, "Đồ ăn vặt" },
            { CategoryEnum.FatsOils, "Dầu, mỡ và bơ" },
            { CategoryEnum.CannedFood, "Đồ đóng hộp" },
            { CategoryEnum.Beverages, "Đồ uống" },
            { CategoryEnum.SweetsSugars, "Đồ ngọt" },
            { CategoryEnum.SpicesHerbsCondiments, "Gia vị và nước chấm" },
            { CategoryEnum.FoodAdditives, "Phụ gia" }
        }; 

        static CategoryStorage()
        {
            _categories = GetAllCategories();
        }

        public static Dictionary<int, Category> GetAllCategories()
        {
            if (_categories.Count > 0)
                return _categories;

            Dictionary<int, Category> categories = [];
            var now = DateTimeOffset.Now;
            // skip the first category (Unknown)
            foreach (CategoryEnum category in Enum.GetValues<CategoryEnum>().Skip(1))
            {
                int categoryId = (int) category;
                string categoryName = category.ToString();
                FieldInfo field = category.GetType().GetField(categoryName)!;
                DescriptionAttribute? attribute = (DescriptionAttribute?) Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

                categories.Add(categoryId, new Category
                {
                    Id = categoryId,
                    Name = categoryName,
                    LocalName = _categoryLocalNames[category],
                    Description = attribute?.Description ?? categoryName,
                    CreateBy = AppConstants.Admin,
                    CreateTime = now,
                });
            }
            return categories;
        }

        public static Category GetCategoryById(int id)
        {
            return _categories[id];
        }
    }
}