using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICE_BG.Models
{
    public class OrderCreateBindingModel
    {
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Quantity")]

        public int Quantity { get; set; }


    }
}
