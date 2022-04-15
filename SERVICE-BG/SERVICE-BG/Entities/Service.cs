using SERVICE_BG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICE_BG.Entities
{
    public class Service
    {
        public Service()
        {

            Categories = new List<CategoryPairVM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
     public virtual List<CategoryPairVM> Categories { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
        
        
        
    }
}
