using ApocalypticShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Repositories.Interfaces
{
    public interface IResourceRepository
    {
        Task<Resource> Get(int id);
        Task<IEnumerable<Resource>> GetAll();
    }
}
