using MvcStore.Entities;
using MvcStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();

        [HttpGet]
        public ActionResult Index()
        {
            var categories = categoriesService.GetCategories();
            return View(categories);
        }

       
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoriesService.SaveCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = categoriesService.GetCategory(ID);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoriesService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = categoriesService.GetCategory(ID);

            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {

             categoriesService.DeleteCategory(category.ID);
            //categoriesService.DeleteCategory(category);
            return RedirectToAction("Index");
        }

    }
}