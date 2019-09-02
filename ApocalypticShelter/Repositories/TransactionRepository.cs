using ApocalypticShelter.Data;
using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly StoreDataContext _context;

        public TransactionRepository(StoreDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return _context.Transactions.AsNoTracking().ToList();
        }

        public async Task<Transaction> Get(int id)
        {
            return _context.Transactions.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Transaction> Create(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return transaction;
        }
        public async Task<Transaction> Delete(int Id)
        {
            var transaction = _context.Transactions.Find(Id);
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();

            return transaction;
        }
    }
}
