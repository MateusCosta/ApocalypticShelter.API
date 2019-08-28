using ApocalypticShelter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public TransactionEnums.Type Type { get; set; }
        public Resource Resource { get; set; }
        public DateTime Date { get; set; }
        public int InitialBalance { get; set; }
        public int FinalBalance { get; set; }
        public int QuantityMoved { get; set; }
    }
}
