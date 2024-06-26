﻿using FridgeBE.Core.Entities;
using FridgeBE.Core.Entities.Common;
using FridgeBE.Infrastructure.Data.EntityConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FridgeBE.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _accessor;

        public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _accessor = httpContextAccessor;
        }

        public DbSet<User> Users { get; set; }
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

            new UserConfiguration().Configure(modelBuilder.Entity<User>());

            new IngredientConfiguration().Configure(modelBuilder.Entity<Ingredient>());

            new RecipeConfiguration().Configure(modelBuilder.Entity<Recipe>());

            new IngredientRecipeConfiguration().Configure(modelBuilder.Entity<IngredientRecipe>());

            new StepConfiguration().Configure(modelBuilder.Entity<Step>());
        }
    }
}