﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Models
{
    public class Survivor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  HashPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }

    }
}
