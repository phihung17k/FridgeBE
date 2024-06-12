using FridgeBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeBE.Core.Models
{
    public class IngredientModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public List<RecipeModel> Recipes { get; set; } = [];
    }
}