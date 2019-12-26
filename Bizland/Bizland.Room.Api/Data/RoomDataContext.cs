using Bizland.Infrastructure.Configurations;
using Bizland.Infrastructure.DBContext;
using Bizland.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bizland.Room.Api.Data
{
    public class RoomDataContext : AppDbContext
    {
        public DbSet<Bizland.Domain.Entities.Room> Rooms { get; set; }

        public RoomDataContext(DbContextOptions<RoomDataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class RoomConfiguration : IEntityTypeConfiguration<Bizland.Domain.Entities.Room>
    {
        public void Configure(EntityTypeBuilder<Bizland.Domain.Entities.Room> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
}
