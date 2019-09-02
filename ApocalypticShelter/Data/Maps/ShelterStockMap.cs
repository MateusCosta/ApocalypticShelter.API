using ApocalypticShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Data.Maps
{
    public class ShelterStockMap : IEntityTypeConfiguration<ShelterStock>
    {
        public void Configure(EntityTypeBuilder<ShelterStock> builder)
        {
            builder.ToTable("ShelterStocks");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Resource);
            builder.HasOne(x => x.Shelter);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();

        }
     

    }
}
