using Bizland.Domain.Core.Models;
using Bizland.Infrastructure.Configurations;
using Bizland.Infrastructure.DBContext;
using Bizland.Infrastructure.Extensions;
using Bizland.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bizland.Room.Api.Data
{
    public class RoomDataContext : AppDbContext
    {
        public DbSet<Bizland.Domain.Entities.Room> Rooms { get; set; }

        public DbSet<OutboxMessage> OutBoxes { get; set; }

        public RoomDataContext(DbContextOptions<RoomDataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MessagingDataContextDesignFactory : IDesignTimeDbContextFactory<RoomDataContext>
    //{
    //    public RoomDataContext CreateDbContext(string[] args)
    //    {
    //        var connString = ConfigurationHelper.GetConfiguration("Infrastructures:SqlServer")?.GetConnectionString("ConnString");
    //        var optionsBuilder = new DbContextOptionsBuilder<RoomDataContext>()
    //            .UseSqlServer(
    //                connString,
    //                sqlOptions =>
    //                {
    //                    sqlOptions.MigrationsAssembly(GetType().Assembly.FullName);
    //                    sqlOptions.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
    //                }
    //            );

    //        return new RoomDataContext(optionsBuilder.Options);
    //    }
    //}

    public class RoomConfiguration : IEntityTypeConfiguration<Bizland.Domain.Entities.Room>
    {
        public void Configure(EntityTypeBuilder<Bizland.Domain.Entities.Room> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
    public class OutboxTypeConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("Outboxes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
        }
    }
}
