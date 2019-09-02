using ApocalypticShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Data.Maps
{
    public class SurvivorMap : IEntityTypeConfiguration<Survivor>
    {
        public void Configure(EntityTypeBuilder<Survivor> builder)
        {
            builder.ToTable("Survivors");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Shelter);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(120).HasColumnType("varchar(255)");
            builder.Property(x => x.HashPassword).IsRequired().HasMaxLength(120).HasColumnType("varchar(255)");
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();

        }
    }
}
