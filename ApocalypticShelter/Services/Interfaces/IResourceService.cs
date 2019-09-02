using ApocalypticShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Services.Interfaces
{
    public interface IResourceService
    {
        Resource Get(int ID);
        IEnumerable<Resource> GetAll();

        Resource Create(Resource resource);

        Resource Update(Resource resource);
        Resource Delete(int ID);
    }
}
