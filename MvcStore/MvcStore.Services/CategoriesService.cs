using MvcStore.Database;
using MvcStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStore.Services
{
    public class CategoriesService
    {
        //Get Single Categor From Database
        public Category GetCategory(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(ID);
            }
        }
        //Get Category From Database
        public List<Category> GetCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }
        public List<Category> FeaturedCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.Where(x=>x.isFeatured==true&& x.ImageURL!=null).ToList();
            }
        }
        //Seve Category To Database
        public void SaveCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        //Update Data 
        public void UpdateCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteCategory(int ID)
        {
            using (var context = new CBContext())
            {
                var category = context.Categories.Find(ID);
                //context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
