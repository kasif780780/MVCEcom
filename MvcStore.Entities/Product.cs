using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStore.Entities
{
   public class Product: BaseEntity
    {
        public decimal Price { get; set; }
        public virtual Category Category { get; set; } //Its Shows Category Have a Product


    }
}
