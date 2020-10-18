using HomeApp.Core.Databse.Recipes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.Username).IsUnique();
            });
        }
    }
}
