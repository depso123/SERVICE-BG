using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICE_BG.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string CarModel { get; set; }

    }
}
