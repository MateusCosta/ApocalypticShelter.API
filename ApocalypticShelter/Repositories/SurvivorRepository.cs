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
    public class SurvivorRepository : ISurvivorRepository
    {
        private readonly StoreDataContext _context;

        public SurvivorRepository(StoreDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Survivor>> GetAll()
        {
            return _context.Survivors.AsNoTracking().ToList();
        }

        public async Task<Survivor> Get(int id)
        {
            return _context.Survivors.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Survivor> Create(Survivor survivor)
        {
            _context.Survivors.Add(survivor);
            _context.SaveChanges();

            return survivor;
        }
        public async Task<Survivor> Update(Survivor survivor)
        {
            _context.Entry<Survivor>(survivor).State = EntityState.Modified;
            _context.SaveChanges();

            return survivor;
        }
        public async Task<Survivor> Delete(int Id)
        {
            var survivor = _context.Survivors.Find(Id);
            _context.Survivors.Remove(survivor);
            _context.SaveChanges();

            return survivor;
        }
    }
}
