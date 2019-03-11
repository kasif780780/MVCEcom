using MvcStore.Entities;
using MvcStore.Services;
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
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsService.SaveProduct(product);
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
    }
}