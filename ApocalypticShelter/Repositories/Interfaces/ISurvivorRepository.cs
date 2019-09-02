using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;

namespace ApocalypticShelter.Repositories.Interfaces
{
    public interface ISurvivorRepository
    {
        Task<Survivor> Get(int id);
        Task<IEnumerable<Survivor>> GetAll();
        Task<Survivor> Create(Survivor resource);
        Task<Survivor> Update(Survivor resource);
        Task<Survivor> Delete(int id);
    }
}
