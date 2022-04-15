using SERVICE_BG.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICE_BG.Models
{
    public class OrderListVM
    {
       // [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int ServiceId { get; set; }
        [Display(Name = "Service")]
        public string Service { get; set; }

        public string UserId { get; set; }

        public string  User { get; set; }

        public string CarModel { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }


        public decimal TotalPrice { get; set; }

    }
}
