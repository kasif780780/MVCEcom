using MvcStore.Entities;
using MvcStore.Services;
using MvcStore.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProdcutTable(string search)
        {
            var products = productsService.GetProducts();
            if(string.IsNullOrEmpty(search)==false)
            {
                products = products.Where(p =>p.Name!=null && p.Name.Contains(search)).ToList();
            }
           
            return PartialView(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CategoriesService categoriesService = new CategoriesService();
            var categories = categoriesService.GetCategories();
            return PartialView(categories);
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModels model)
        {
            CategoriesService categoriesService = new CategoriesService();
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Category = categoriesService.GetCategory(model.CategoryID);
           productsService.SaveProduct(newProduct);
            return RedirectToAction("ProdcutTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productsService.GetProduct(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        { 
            productsService.UpdateProduct(product);
            return RedirectToAction("ProdcutTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productsService.DeleteProduct(ID);
            return RedirectToAction("ProdcutTable");
        }
    }
}