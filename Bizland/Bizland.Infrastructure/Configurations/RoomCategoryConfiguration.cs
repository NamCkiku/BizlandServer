﻿using Bizland.Domain.Entities;
using Bizland.Infrastructure.Extensions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bizland.Infrastructure.Configurations
{
    public class RoomCategoryConfiguration : DbEntityConfiguration<RoomCategory>
    {
        public override void Configure(EntityTypeBuilder<RoomCategory> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
}