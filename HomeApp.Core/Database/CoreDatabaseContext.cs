using HomeApp.Core.Database.Bills;
using HomeApp.Core.Database.Bills.Bill;
using HomeApp.Core.Database.Bills.Income;
using HomeApp.Core.Database.Recipes.Models;
using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.Databse.Users.Models;
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
        //Recipes DB
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RecipeProductQuantity> RecipesProductQuantity { get; set; }

        //Finance Managment Db
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Savings> Savings { get; set; }
        public DbSet<BillType> BillsType { get; set; }
        public DbSet<Bill> Bills { get; set; }
        //
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("core");
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
            BillsBuilder.BuildBillsEntities(builder);
        }
    }
}
#pragma warning restore CS8618 // Nienullowalne pole jest niezainicjowane. Rozważ zadeklarowanie go jako nullowalnego.
