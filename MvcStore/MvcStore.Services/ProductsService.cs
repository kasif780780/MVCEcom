using MvcStore.Database;
using MvcStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MvcStore.Services
{
    public class ProductsService
    {
        //Get Single Categor From Database
        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID);
            }
        }
        //Get Category From Database
        public List<Product> GetProducts()
        {
            //var context = new CBContext();
            //    return context.Products.ToList();
            using (var context = new CBContext())
            {
                return context.Products.Include(x=>x.Category).ToList();
            }
        }
        //Seve Category To Database
        public void SaveProduct(Product product)
        {
           
            using (var context = new CBContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        //Update Data 
        public void UpdateProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                var product = context.Products.Find(ID);
                //context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
