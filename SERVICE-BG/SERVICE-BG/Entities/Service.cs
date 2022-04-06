﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICE_BG.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
        
        
        
    }
}
