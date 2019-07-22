using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SklepKompMVC.DAL;
using SklepKompMVC.Infrastructure;
using SklepKompMVC.ViewModel;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using SklepKompMVC.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SklepKompMVC.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;

        private ISessionManager sessionManager { get; set; }

        private StoreContext Db = new StoreContext();

        public CartController()
        {
            this.sessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.Db);
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel
            {
                CartItem = cartItems,
                TotalPrice = cartTotalPrice
            };

            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            shoppingCartManager.AddToCart(id);
            return RedirectToAction("Index");
        }

        public int GetCartItemCount()
        {
            return shoppingCartManager.GetCartItemCount();
        }

        public ActionResult RemoveFromCart(int id)
        {
            shoppingCartManager.RemoveFromCart(id);
            //int itemCount = shoppingCartManager.RemoveFromCart(productID);
            //int cartItemCount = shoppingCartManager.GetCartItemCount();
            //decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            //var res = new CartRemoveViewModel
            //{
            //    RemoveItemId = productID,
            //    RemovedItemCount = itemCount,
            //    CartTotal = cartTotal,
            //    CartItemCount = cartItemCount
            //};
            //return Json(res);
            return RedirectToAction("Index");
        }


        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }

        }

        public ActionResult Checkout()
        {
            if (Request.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();

                var user = Db.UserDatas.Where(a => a.UserDataId == userID).SingleOrDefault();
                if (user != null)
                {
                    var order = new Order()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        City = user.City,
                        AddresCode = user.AddresCode,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber

                    };
                    return View(order);
                }
                return View();


            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Cart") });
            }
        }
        [HttpPost]
        public ActionResult Checkout(Order orderdetails)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();

                var newOrder = shoppingCartManager.CreateOrder(orderdetails, userID);

                var user = Db.UserDatas.Where(a => a.UserDataId == userID).SingleOrDefault();

               

                if (user !=null)
                {
                    shoppingCartManager.EmptyCart();



                    //var editUser = new UserData()
                    //{

                    user.UserDataId = userID;
                    user.FirstName = orderdetails.FirstName;
                    user.LastName = orderdetails.LastName;
                    user.Address = orderdetails.Address;
                    user.City = orderdetails.City;
                    user.AddresCode = orderdetails.AddresCode;
                    user.Email = orderdetails.Email;
                    user.PhoneNumber = orderdetails.PhoneNumber;
                    //};

                    Db.Entry(user).State = EntityState.Modified;
                    Db.SaveChanges();

                }
                else
                {
                    var newUser = new UserData()
                    {
                        UserDataId = userID,
                        FirstName = orderdetails.FirstName,
                        LastName = orderdetails.LastName,
                        Address = orderdetails.Address,
                        City = orderdetails.City,
                        AddresCode = orderdetails.AddresCode,
                        Email = orderdetails.Email,
                        PhoneNumber = orderdetails.PhoneNumber
                    };
                    Db.UserDatas.Add(newUser);
                    Db.SaveChanges();

                }


                return RedirectToAction("OrderConfirmation");
            }
            else
            {
                return View(orderdetails);
            }
        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }


    }
}