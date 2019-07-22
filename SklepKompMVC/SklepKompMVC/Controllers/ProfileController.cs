using Microsoft.AspNet.Identity;
using SklepKompMVC.DAL;
using SklepKompMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepKompMVC.Controllers
{


    [Authorize]
    public class ProfileController : Controller
    {
        StoreContext Db = new StoreContext();
        // GET: Profile
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();

                UserData userdata = Db.UserDatas.Find(userID);

                return View(userdata);


            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Profile") });
            }

        }
        public ActionResult OrderHistory()
        {
            if (Request.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();

                var order = Db.Orders.Where(a => a.UserDataId == userID);



                //UserData userdata = Db.UserDatas.Find(userID);

                return View(order);


            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Profile") });
            }
        }

    }
}