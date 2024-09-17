using FridgeBE.Core.Entities.Common;
using FridgeBE.Core.Enums;
using FridgeBE.Core.Services;

namespace FridgeBE.Core.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalName { get; set; }
        public string? Description {  get; set; }

        // foreign
        public List<Ingredient> Ingredients { get; set; }

        // implicit: CategoryEnum = Category
        // explicit: Category = (Category)CategoryEnum

        public static implicit operator CategoryEnum(Category category)
        {
            return category.Equals(null) ? CategoryEnum.Unknown : (CategoryEnum) category.Id;
        }

        public static implicit operator Category(CategoryEnum category)
        {
            return CategoryStorageService.GetCategoryById((int) category);
        }

        public static bool operator ==(Category category, Category other)
        {
            if (ReferenceEquals(category, other)) 
                return true;

            if (ReferenceEquals(category, null)) 
                return false;

            return category.Equals(other);
        }

        public static bool operator !=(Category category, Category other)
        {
            return !(category == other);
        }

        public static bool operator ==(Category category, CategoryEnum categoryEnum)
        {
            return category is not null && category.Id == (int) categoryEnum;
        }

        public static bool operator !=(Category category, CategoryEnum categoryEnum)
        {
            return !(category == categoryEnum);
        }

        public override bool Equals(object? obj)
        {
            var category = obj as Category;
            return category is not null && Id == category.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}