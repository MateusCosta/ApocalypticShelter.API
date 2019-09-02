using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using ApocalypticShelter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Services
{
    public class ShelterStockService : IShelterStockService
    {
        private readonly IShelterStockRepository _repository;
        public ShelterStockService(IShelterStockRepository repository)
        {
            _repository = repository;
        }

        public ShelterStock Get(int id)
        {
            return _repository.Get(id).Result;
        }

        public IEnumerable<ShelterStock> GetAll()
        {
            return _repository.GetAll().Result;
        }

        public ShelterStock Create(ShelterStock shelterStock)
        {
            return _repository.Create(shelterStock).Result;
        }

        public ShelterStock Update(ShelterStock shelterStock)
        {
            return _repository.Update(shelterStock).Result;
        }

        public ShelterStock Delete(int id)
        {
            return _repository.Delete(id).Result;
        }
    }
}

