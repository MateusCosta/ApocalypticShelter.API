using ApocalypticShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Services.Interfaces
{
    public interface IShelterService
    {
        Shelter Get(int ID);
        IEnumerable<Shelter> GetAll();

        Shelter Create(Shelter shelter);

        Shelter Update(Shelter shelter);
        Shelter Delete(int ID);
    }
}
