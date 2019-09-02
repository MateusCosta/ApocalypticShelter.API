using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;
namespace ApocalypticShelter.Services.Interfaces
{
    public interface ISurvivorService
    {
        Survivor Get(int ID);
        IEnumerable<Survivor> GetAll();

        Survivor Create(Survivor shelterStock);

        Survivor Update(Survivor shelterStock);
        Survivor Delete(int ID);

    }
}
