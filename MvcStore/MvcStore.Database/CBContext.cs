using MvcStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStore.Database
{
   public class CBContext:DbContext


    {
        public CBContext() : base("DefaultConnection")
        {


        }
            
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
