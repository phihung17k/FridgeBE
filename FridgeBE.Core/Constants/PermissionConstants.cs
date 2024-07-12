namespace FridgeBE.Api.Constants
{
    public static class PermissionConstants
    {
        public const string ClaimType = "Permission";

        public static class View
        {
            public const string AllIngredients = $"{nameof(View)}.{nameof(AllIngredients)}";
            
        }

        public static class Edit
        {
            public const string Ingredient = $"{nameof(Edit)}.{nameof(Ingredient)}";
            public const string Recipe = $"{nameof(Edit)}.{nameof(Recipe)}";
        }

    }
}