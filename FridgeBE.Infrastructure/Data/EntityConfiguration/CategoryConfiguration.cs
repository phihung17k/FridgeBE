using FridgeBE.Core.Entities;
using FridgeBE.Infrastructure.Data.DataSeeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeBE.Infrastructure.Data.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category).ToLowerInvariant());

            builder.HasMany(c => c.Ingredients)
                   .WithOne(i => i.Category)
                   .HasForeignKey(i => i.CategoryId)
                   .IsRequired(false);

            builder.HasData(CategorySeeding.SeedCategories());
        }
    }
}