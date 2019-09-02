using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;

namespace ApocalypticShelter.Repositories.Interfaces
{
    public interface IShelterRepository
    {
        Task<Shelter> Get(int id);
        Task<IEnumerable<Shelter>> GetAll();
        Task<Shelter> Create(Shelter shelter);
        Task<Shelter> Update(Shelter shelter);
        Task<Shelter> Delete(int id);
    }
}
