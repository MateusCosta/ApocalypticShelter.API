using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using ApocalypticShelter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Transaction Get(int id)
        {
            return _repository.Get(id).Result;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _repository.GetAll().Result;
        }

        public Transaction Create(Transaction transaction)
        {
            return _repository.Create(transaction).Result;
        }

        public Transaction Delete(int Id)
        {
            return _repository.Delete(Id).Result;
        }
    }
}
