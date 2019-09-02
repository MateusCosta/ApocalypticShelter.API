using ApocalypticShelter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.ViewModels.TransactionViewModels
{
    public class CreateTransactionViewModel
    {
        public int Id { get; set; }
        public TransactionEnums.Type Type { get; set; }
        public int ResourceId { get; set; }
        public int ShelterId { get; set; }
        public int SurvivorId { get; set; }
        public int QuantityMoved { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
