using Bizland.Domain.Core;
using Bizland.Infrastructure.Configurations;
using Bizland.Infrastructure.Helper;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System;

namespace Bizland.Infrastructure.DBContext
{
    public class EventStoreSQLContext : DbContext
    {
        public EventStoreSQLContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DesignTimeEventStoreDbContextFactory : IDesignTimeDbContextFactory<EventStoreSQLContext>
    {
        public EventStoreSQLContext CreateDbContext(string[] args)
        {
            var connString = ConfigurationHelper.GetConfiguration(AppContext.BaseDirectory)?.GetConnectionString("DefaultConnection");
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(connString);
            return new EventStoreSQLContext(builder.Options);
        }
    }
}