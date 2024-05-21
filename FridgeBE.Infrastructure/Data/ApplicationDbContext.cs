using FridgeBE.Core.Entities;
using FridgeBE.Core.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FridgeBE.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _accessor;

        public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _accessor = httpContextAccessor;
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
        public DbSet<Step> Steps { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();
            foreach (EntityEntry<AuditableEntity> entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    //case EntityState.Deleted:
                    //          entityEntry.Entity.DeleteBy = "usedId";
                    //          entityEntry.Entity.DeleteTime = DateTimeOffset.Now;
                    //    break;
                    case EntityState.Modified:
                        if (string.Equals("delete", _accessor.HttpContext.Request.Method, StringComparison.InvariantCultureIgnoreCase))
                        {
                            entityEntry.Entity.DeleteBy = "usedId";
                            entityEntry.Entity.DeleteTime = DateTimeOffset.Now;
                        }
                        else
                        {
                            entityEntry.Entity.UpdateBy = "usedId";
                            entityEntry.Entity.UpdateTime = DateTimeOffset.Now;
                        }
                        break;
                    case EntityState.Added:
                        entityEntry.Entity.CreateBy = "usedId";
                        entityEntry.Entity.CreateTime = DateTimeOffset.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ingredient>(i =>
            {
                // default database set up to be an IDENTITY, else try using [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                //i.Property(i => i.Id);

                // case DateTimeOffset can't convert to mysql, using value converter
                //i.Property(i => i.CreateTime);

                //i.HasMany(i => i.Recipes)
                //.WithMany(r => r.Ingredients)
                //.UsingEntity<IngredientRecipe>();
            });
        }
    }
}