using FridgeBE.Core.Entities;
using FridgeBE.Core.Entities.Common;
using FridgeBE.Infrastructure.Data.EntityConfiguration;
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

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserAccountPermission> UserAccountPermissions { get; set; }


        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
        public DbSet<Step> Steps { get; set; }

        public new int SaveChanges(bool forceDelete = false)
        {
            auditEntity(forceDelete);
            return base.SaveChanges();
        }

        public new async Task<int> SaveChangesAsync(bool forceDelete = false, CancellationToken cancellationToken = default)
        {
            auditEntity(forceDelete);
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void auditEntity(bool forceDelete)
        {
            IEnumerable<EntityEntry<AuditableEntity>> entries = ChangeTracker.Entries<AuditableEntity>();
            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Modified:
                        if (string.Equals("delete", _accessor.HttpContext.Request.Method, StringComparison.InvariantCultureIgnoreCase))
                        {
                            // log delete action
                            if (!forceDelete)
                            {
                                entityEntry.Entity.DeleteBy = "usedId";
                                entityEntry.Entity.DeleteTime = DateTimeOffset.Now;
                                //entityEntry.Entity.GetType().GetProperty("DeleteBy")?.SetValue(entityEntry.Entity, "usedId");
                                //entityEntry.Entity.GetType().GetProperty("DeleteTime")?.SetValue(entityEntry.Entity, DateTimeOffset.Now);
                            }
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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserAccountConfiguration().Configure(modelBuilder.Entity<UserAccount>());

            new UserLoginConfiguration().Configure(modelBuilder.Entity<UserLogin>());

            new PermissionConfiguration().Configure(modelBuilder.Entity<Permission>());

            new UserAccountPermissionConfiguration().Configure(modelBuilder.Entity<UserAccountPermission>());

            new IngredientConfiguration().Configure(modelBuilder.Entity<Ingredient>());

            new RecipeConfiguration().Configure(modelBuilder.Entity<Recipe>());

            new IngredientRecipeConfiguration().Configure(modelBuilder.Entity<IngredientRecipe>());

            new StepConfiguration().Configure(modelBuilder.Entity<Step>());
        }
    }
}