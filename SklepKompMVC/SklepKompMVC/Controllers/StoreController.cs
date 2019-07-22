using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SklepKompMVC.DAL;

namespace SklepKompMVC.Controllers
{
    public class StoreController : Controller
    {
        StoreContext Db = new StoreContext();
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var product = Db.Products.Find(id);
            return View(product);
        }

        public ActionResult List(string categoryname)
        {
            var category = Db.Categories.Include("Products").Where(g => g.CategoryName.ToUpper() == categoryname.ToUpper()).Single();
            var products = category.Products.ToList();

            return View(products);
        }
        [OutputCache(Duration = 80000)]
        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = Db.Categories.ToList();

            return PartialView("_CategoriesMenu", categories);
        }
    }
}