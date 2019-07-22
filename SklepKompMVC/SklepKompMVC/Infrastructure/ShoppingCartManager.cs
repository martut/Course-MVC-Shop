using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SklepKompMVC.DAL;
using SklepKompMVC.Models;
using System.Data.Entity;

namespace SklepKompMVC.Infrastructure
{
    public class ShoppingCartManager
    {
        private StoreContext Db;

        private ISessionManager session;

        public const string CartSessionKey = "CartData";

        public ShoppingCartManager(ISessionManager session, StoreContext Db)
        {
            this.session = session;
            this.Db = Db;
        }

        public void AddToCart(int productid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Product.ProductId == productid);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                var productToAdd = Db.Products.Where(a => a.ProductId == productid).SingleOrDefault();
                if (productToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Product = productToAdd,
                        Quantity = 1,
                        TotalPrice = productToAdd.Price
                    };

                    cart.Add(newCartItem);
                }
            }

            session.Set(CartSessionKey, cart);
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (session.Get<List<CartItem>>(CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }
            return cart;
        }

        public void RemoveFromCart(int productid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Product.ProductId == productid);

            if (cartItem!=null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }
            session.Set(CartSessionKey, cart);
        }


        public int RemoveFromCart1(int productid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Product.ProductId == productid);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                {
                    cart.Remove(cartItem);
                }

            }
            return 0;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();

            return cart.Sum(c => (c.Quantity * c.Product.Price));
        }

        public int GetCartItemCount()
        {
            var cart = this.GetCart();

            int count = cart.Sum(c => c.Quantity);

            return count;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = this.GetCart();

            newOrder.DateCreated = DateTime.Now;
            newOrder.UserDataId = userId;
            

            this.Db.Orders.Add(newOrder);

            if (newOrder.OrderItem == null)
            {
                newOrder.OrderItem = new List<OrderItem>();
            }

            decimal cartTotal = 0;

            foreach (var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductId = cartItem.Product.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                };

                cartTotal += (cartItem.Quantity * cartItem.Product.Price);

                newOrder.OrderItem.Add(newOrderItem);
            }

            newOrder.TotalPrice = cartTotal;

           


            this.Db.SaveChanges();

            newOrder.OrderHistoryId = String.Format("#{0}-{1}", newOrder.OrderId, newOrder.DateCreated.Date);
            Db.Entry(newOrder).State = EntityState.Modified;

            this.Db.SaveChanges();

            return newOrder;

        }

        public void EmptyCart()
        {
            session.Set<List<CartItem>>(CartSessionKey, null);
        }

    }
}