using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using ApocalypticShelter.Services.Interfaces;
using ApocalypticShelter.ViewModels.TransactionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Enums;
namespace ApocalypticShelter.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IShelterStockRepository _stockRepository;
        public TransactionService(ITransactionRepository repository, IShelterStockRepository stockRepository)
        {
            _repository = repository;
            _stockRepository = stockRepository;
        }

        public Transaction Get(int id)
        {
            return _repository.Get(id).Result;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _repository.GetAll().Result;
        }

        public Transaction Create(CreateTransactionViewModel model)
        {
            var create = false;
            var stock = _stockRepository.GetStock(model.ShelterId, model.ResourceId).Result;
            if(stock == null)
            {
                create = true;
                stock = new ShelterStock();
                stock.ShelterId = model.ShelterId;
                stock.ResourceId = model.ResourceId;
                stock.CreatedAt = DateTime.Now;
                stock.UpdatedAt = DateTime.Now;
                stock.Quantity = 0;
               
            }
            var transaction = new Transaction();
            transaction.Type = model.Type;
            transaction.QuantityMoved = model.QuantityMoved;

            transaction.InitialBalance = stock.Quantity;
            if(transaction.Type == TransactionEnums.Type.Acquire)
            {
                transaction.FinalBalance = Convert.ToInt32(Math.Abs(model.QuantityMoved)) + transaction.InitialBalance;
            }
            else
            {
                transaction.FinalBalance = Convert.ToInt32(Math.Abs(model.QuantityMoved)) - transaction.InitialBalance;
            }

            stock.Quantity = transaction.FinalBalance;
            transaction.ShelterId = model.ShelterId;
            transaction.ResourceId = model.ShelterId;
            transaction.SurvivorId = model.SurvivorId;
            transaction.CreatedAt = DateTime.Now;
            if (create)
            {
                _stockRepository.Create(stock);
            }
            else
            {
                _stockRepository.Update(stock);
            }
           
            return _repository.Create(transaction).Result;
        }

        public Transaction Delete(int Id)
        {
            return _repository.Delete(Id).Result;
        }
    }
}
