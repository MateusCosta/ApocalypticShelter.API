using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Models
{
    public class Resource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; }
        public bool Perishable { get; set; }
        public DateTime? ShelfLife { get; set; }
        public bool Enabled { get; set; }
    }
}
