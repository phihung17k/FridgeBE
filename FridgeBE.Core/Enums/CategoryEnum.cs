using System.ComponentModel;

namespace FridgeBE.Core.Enums
{
    public enum CategoryEnum
    {
        Unknown = 0,
        Cereals,
        [Description("Roots, tubers and plantains")]
        RootsTubersPlantains,
        Legumes,
        Vegetables,
        Fruits,
        [Description("Seeds and nuts")]
        SeedsNuts,
        Meat,
        [Description("Insects and grubs")]
        InsectsGrubs,
        [Description("Fish and shellfish")]
        FishShellfish,
        Eggs,
        [Description("Milk and dairy products")]
        MilkDairy,
        Snacks,
        [Description("Fats and oils")]
        FatsOils,
        [Description("Canned Food")]
        CannedFood,
        Beverages,
        [Description("Sweets and sugars")]
        SweetsSugars,
        [Description("Spices, herbs and condiments")]
        SpicesHerbsCondiments,
        [Description("Food additives")]
        FoodAdditives
    }
}