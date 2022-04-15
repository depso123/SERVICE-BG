using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICE_BG.Models
{
    public class CategoryPairVM
    {
        public int Id { get; set; }


        [Display(Name = "Category")]
        public string CategoryName { get; set; }
    }
}
