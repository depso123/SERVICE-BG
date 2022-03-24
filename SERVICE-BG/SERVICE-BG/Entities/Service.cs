using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICE_BG.Entities
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category  Category {get; set;}

        public decimal Price { get; set; 
        
        }
    }
}
