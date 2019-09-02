using ApocalypticShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Data.Maps
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Resource);
            builder.HasOne(x => x.Shelter);
            builder.HasOne(x => x.Survivor);
            builder.Property(x => x.InitialBalance).IsRequired();
            builder.Property(x => x.FinalBalance).IsRequired();
            builder.Property(x => x.QuantityMoved).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
           
    }
    }
}
