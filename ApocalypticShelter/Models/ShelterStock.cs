using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Models
{
    public class ShelterStock
    {
        public int Id { get; set; }
        public  Resource Resource { get; set; }
        public int ResourceId { get; set; }
        public Shelter Shelter { get; set; }
        public int ShelterId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
