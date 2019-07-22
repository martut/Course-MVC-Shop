using SklepKompMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SklepKompMVC.ViewModel;

namespace SklepKompMVC.Controllers
{
    public class HomeController : Controller
    {
        StoreContext Db = new StoreContext();

        public ActionResult Index()
        {
            var categories = Db.Categories.ToList();

            var newArrivals = Db.Products.Where(a => !a.IsHidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();

            var bestsellers = Db.Products.Where(a => !a.IsHidden && a.IsBestseller).OrderBy(g => Guid.NewGuid()).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                Bestsellers = bestsellers,
                NewArrivals = newArrivals,
                Categories = categories
            };
            
            return View(vm);
        }

       
        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }

        //public ActionResult AdminPages(string controllername)
        //{
        //    return RedirectToAction("Index", controllername);
        //}
        [ChildActionOnly]
        public ActionResult NavbarMenu()
        {
            var categories = Db.Categories.ToList();

            var newArrivals = Db.Products.Where(a => !a.IsHidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();

            var bestsellers = Db.Products.Where(a => !a.IsHidden && a.IsBestseller).OrderBy(g => Guid.NewGuid()).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                Bestsellers = bestsellers,
                NewArrivals = newArrivals,
                Categories = categories
            };
            return PartialView("_NavbarMenu",vm);
        }

    }
}