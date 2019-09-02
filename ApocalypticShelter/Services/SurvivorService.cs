using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using ApocalypticShelter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Services
{
    public class SurvivorService : ISurvivorService
    {
        private readonly ISurvivorRepository _repository;
        public SurvivorService(ISurvivorRepository repository)
        {
            _repository = repository;
        }

        public Survivor Get(int id)
        {
            return _repository.Get(id).Result;
        }

        public IEnumerable<Survivor> GetAll()
        {
            return _repository.GetAll().Result;
        }

        public Survivor Create(Survivor survivor)
        {
            return _repository.Create(survivor).Result;
        }

        public Survivor Update(Survivor survivor)
        {
            return _repository.Update(survivor).Result;
        }

        public Survivor Delete(int id)
        {
            return _repository.Delete(id).Result;
        }
    }
}

