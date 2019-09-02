using ApocalypticShelter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionEnums.Type Type { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public Shelter Shelter { get; set; }
        public int ShelterId { get; set; }
        public Survivor Survivor { get; set; }
        public int SurvivorId { get; set; }
        public int InitialBalance { get; set; }
        public int FinalBalance { get; set; }
        public int QuantityMoved { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
