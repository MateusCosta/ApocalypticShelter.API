using ApocalypticShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Data.Maps
{
    public class ResourceMap: IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255).HasColumnType("varchar(255)");
            builder.Property(x => x.Observation).IsRequired().HasMaxLength(255).HasColumnType("varchar(255)");
            builder.Property(x => x.Enabled).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();

    }
    }
}
