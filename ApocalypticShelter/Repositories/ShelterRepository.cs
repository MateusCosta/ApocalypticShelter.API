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
    public class ShelterRepository : IShelterRepository
    {
        private readonly StoreDataContext _context;

        public ShelterRepository(StoreDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Shelter>> GetAll()
        {
            return _context.Shelters.AsNoTracking().ToList();
        }

        public async Task<Shelter> Get(int id)
        {
            return _context.Shelters.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Shelter> Create(Shelter shelter)
        {
            _context.Shelters.Add(shelter);
            _context.SaveChanges();

            return shelter;
        }
        public async Task<Shelter> Update(Shelter shelter)
        {
            _context.Entry<Shelter>(shelter).State = EntityState.Modified;
            _context.SaveChanges();

            return shelter;
        }
        public async Task<Shelter> Delete(int Id)
        {
            var shelter = _context.Shelters.Find(Id);
            _context.Shelters.Remove(shelter);
            _context.SaveChanges();

            return shelter;
        }
    }
}
