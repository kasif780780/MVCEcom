using MvcStore.Database;
using MvcStore.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private CBContext db = new CBContext();
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels();
             model.Categories = db.Categories.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}