namespace FridgeBE.Api.Constants
{
    public static class PermissionConstants
    {
        public const string ClaimType = "Permission";

        public const string ViewAllIngredients = $"{ClaimType}.{nameof(ViewAllIngredients)}";
    }
}