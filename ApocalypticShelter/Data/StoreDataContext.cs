using ApocalypticShelter.Data.Maps;
using ApocalypticShelter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<ShelterStock> ShelterStocks { get; set; }
        public DbSet<Survivor> Survivors { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=32769;User Id=mateus;Password=mateus1337; Database=shelterdb");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ResourceMap());
            builder.ApplyConfiguration(new ShelterMap());
            builder.ApplyConfiguration(new ShelterStockMap());
            builder.ApplyConfiguration(new SurvivorMap());
            builder.ApplyConfiguration(new TransactionMap());
        }
    }
}
