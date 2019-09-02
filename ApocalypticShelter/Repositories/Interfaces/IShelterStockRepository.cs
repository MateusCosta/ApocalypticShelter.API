using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;

namespace ApocalypticShelter.Repositories.Interfaces
{
    public interface IShelterStockRepository
    {
        Task<ShelterStock> Get(int id);
        Task<IEnumerable<ShelterStock>> GetAll();
        Task<ShelterStock> Create(ShelterStock shelterStock);
        Task<ShelterStock> Update(ShelterStock shelterStock);
        Task<ShelterStock> Delete(int id);
    }
}
