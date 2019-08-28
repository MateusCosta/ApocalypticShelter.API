using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using ApocalypticShelter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _repositorio;
        public ResourceService(IResourceRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Resource Get(int id)
        {
            return _repositorio.Get(id).Result;
        }

        public IEnumerable<Resource> GetAll()
        {
            return _repositorio.GetAll().Result;
        }
    }
}

