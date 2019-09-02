using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;
using ApocalypticShelter.ViewModels.TransactionViewModels;

namespace ApocalypticShelter.Services.Interfaces
{
    public interface ITransactionService
    {
        Transaction Get(int ID);
        IEnumerable<Transaction> GetAll();
        Transaction Create(CreateTransactionViewModel transaction);
        Transaction Delete(int ID);

    }
}
