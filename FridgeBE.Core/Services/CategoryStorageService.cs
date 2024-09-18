using FridgeBE.Core.Entities;

namespace FridgeBE.Core.Services
{
    public static class CategoryStorageService
    {
        //public static Dictionary<int, Category> CachedCategories;

        //public static void Initialize(Dictionary<int, Category>  cachedCategories)
        //{
        //    CachedCategories = cachedCategories;
        //}

        public static Func<int, Category> GetCategoryById { get; set; }
    }
}