using ApocalypticShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> Get(int id);
        Task<IEnumerable<Transaction>> GetAll();

        Task<Transaction> Create(Transaction transaction);

        Task<Transaction> Delete(int id);

    }
}
