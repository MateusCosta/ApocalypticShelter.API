using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using ApocalypticShelter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Services
{
    public class ShelterService: IShelterService
    {
        private readonly IShelterRepository _repository;
        public ShelterService(IShelterRepository repository)
        {
            _repository = repository;
        }

        public Shelter Get(int id)
        {
            return _repository.Get(id).Result;
        }

        public IEnumerable<Shelter> GetAll()
        {
            return _repository.GetAll().Result;
        }

        public Shelter Create(Shelter shelter)
        {
            return _repository.Create(shelter).Result;
        }

        public Shelter Update(Shelter shelter)
        {
            return _repository.Update(shelter).Result;
        }

        public Shelter Delete(int id)
        {
            return _repository.Delete(id).Result;
        }
    }
}
