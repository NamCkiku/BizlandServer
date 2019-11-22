using Bizland.Domain.Entities.Entities;
using Bizland.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.Configurations
{
    public class RoomConfiguration : DbEntityConfiguration<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
}
