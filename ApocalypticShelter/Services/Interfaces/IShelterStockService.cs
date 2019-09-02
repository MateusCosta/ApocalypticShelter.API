using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;
namespace ApocalypticShelter.Services.Interfaces
{
    public interface IShelterStockService
    {
        ShelterStock Get(int ID);
        IEnumerable<ShelterStock> GetAll();

        ShelterStock Create(ShelterStock shelterStock);

        ShelterStock Update(ShelterStock shelterStock);
        ShelterStock Delete(int Id);
    }
}
