﻿using ApocalypticShelter.Models;
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
        private readonly IResourceRepository _repository;
        public ResourceService(IResourceRepository repository)
        {
            _repository = repository;
        }

        public Resource Get(int id)
        {
            return _repository.Get(id).Result;
        }

        public IEnumerable<Resource> GetAll()
        {
            return _repository.GetAll().Result;
        }

        public Resource Create(Resource resource)
        {
            return _repository.Create(resource).Result;
        }

        public Resource Update(Resource resource)
        {
            return _repository.Update(resource).Result;
        }

        public Resource Delete(int id)
        {
            return _repository.Delete(id).Result;
        }
    }
}

