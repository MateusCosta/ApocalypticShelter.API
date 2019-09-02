using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;
namespace ApocalypticShelter.Services.Interfaces
{
    public interface ITransactionService
    {
        Transaction Get(int ID);
        IEnumerable<Transaction> GetAll();
        Transaction Create(Transaction transaction);
        Transaction Delete(int ID);

    }
}
