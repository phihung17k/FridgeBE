using FridgeBE.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgeBE.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ingredient> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ingredient>(i => {
                // default database set up to be an IDENTITY, else try using [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                //i.Property(i => i.Id);

                // case DateTimeOffset can't convert to mysql, using value converter
                i.Property(i => i.CreateTime);
            });
        }
    }
}