using HomeApp.Core.Database.Recipes.Models;
using HomeApp.Core.Databse.Recipes.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Nienullowalne pole jest niezainicjowane. Rozważ zadeklarowanie go jako nullowalnego.
namespace HomeApp.Core.Database
{
    public class CoreDatabaseContext : DbContext
    {
        public CoreDatabaseContext(DbContextOptions<CoreDatabaseContext> options)
: base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RecipeProductQuantity> RecipesProductQuantity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.Username).IsUnique();
            });
            builder.Entity<Recipe>(entity =>
            {
                entity.HasIndex(e => e.RecipeName).IsUnique();
            });
            builder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}
#pragma warning restore CS8618 // Nienullowalne pole jest niezainicjowane. Rozważ zadeklarowanie go jako nullowalnego.
