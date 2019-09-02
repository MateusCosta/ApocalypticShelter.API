using ApocalypticShelter.Data;
using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Repositories
{
    public class ShelterStockRepository : IShelterStockRepository
    {
        private readonly StoreDataContext _context;

        public ShelterStockRepository(StoreDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShelterStock>> GetAll()
        {
            return _context.ShelterStocks.AsNoTracking().ToList();
        }

        public async Task<ShelterStock> Get(int id)
        {
            return _context.ShelterStocks.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<ShelterStock> Create(ShelterStock shelterStock)
        {
            _context.ShelterStocks.Add(shelterStock);
            _context.SaveChanges();

            return shelterStock;
        }
        public async Task<ShelterStock> Update(ShelterStock shelterStock)
        {
            _context.Entry<ShelterStock>(shelterStock).State = EntityState.Modified;
            _context.SaveChanges();

            return shelterStock;
        }
        public async Task<ShelterStock> Delete(int Id)
        {
            var shelterStock = _context.ShelterStocks.Find(Id);
            _context.ShelterStocks.Remove(shelterStock);
            _context.SaveChanges();

            return shelterStock;
        }
    }
}
