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
    public class ResourceRepository : IResourceRepository
    {
        private readonly StoreDataContext _context;

        public ResourceRepository(StoreDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resource>> GetAll()
        {
            return _context.Resources.AsNoTracking().ToList();
        }

        public async Task<Resource> Get(int id)
        {
            return _context.Resources.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Resource> Create(Resource resource)
        {
            _context.Resources.Add(resource);
            _context.SaveChanges();

            return resource;
        }

        public async Task<Resource> Update(Resource resource)
        {
            _context.Entry<Resource>(resource).State = EntityState.Modified;
            _context.SaveChanges();

            return resource;
        }

        public async Task<Resource> Delete(int Id)
        {
            var resource = _context.Resources.Find(Id);
            _context.Resources.Remove(resource);
            _context.SaveChanges();

            return resource;
        }


    }
}
