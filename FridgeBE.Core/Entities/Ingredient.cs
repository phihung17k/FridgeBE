﻿using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Entities
{
    public class Ingredient : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public List<Recipe> Recipes { get; set; } = [];
    }
}