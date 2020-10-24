using HomeApp.Core.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeApp.Test.Database
{
    public class DatabaseFixture : IDisposable
    {

        public DatabaseFixture()
        {
            var connectionString = File.ReadAllText("ConnectionString.txt");
            var builder = new DbContextOptionsBuilder<CoreDatabaseContext>();
            builder.UseNpgsql(connectionString);
            DbContext = new CoreDatabaseContext(builder.Options);
            DbContext.Database.Migrate();
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            DbContext.Database.EnsureDeleted();
        }

        public CoreDatabaseContext DbContext { get; }
    }

}
