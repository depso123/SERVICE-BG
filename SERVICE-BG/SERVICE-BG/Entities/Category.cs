using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICE_BG.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Service>Services { get; set; }
    }
}
