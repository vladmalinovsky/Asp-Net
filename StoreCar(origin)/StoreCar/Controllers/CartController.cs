using StoreCar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreCar.Controllers
{
    public class CartController : Controller
    {
        private StoreCarDB db = new StoreCarDB();
        
        public RedirectToRouteResult AddToCart(Cart cart, int? productId)
        {
            Product product = db.Products.Find(productId);
            if (product != null)
            {
               cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", "Cart");
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId)
        {
            Product product = db.Products.Find(productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", "Cart");
        }
        
        public ViewResult Index(Cart cart)
        {
            return View(new CartIndexViewModel
            {
               Cart = cart
            });
        }

        public RedirectToRouteResult Checkout(Cart cart)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
                     
            cart.TotalPrice = cart.ComputeTotalValue();
            cart.UserName = User.Identity.Name.ToString();
            var lns = cart.Lines.ToList();
            foreach (var l in lns)
            {
                db.Products.Attach(l.Product);
            }
            db.Carts.Add(cart);
            db.SaveChanges();
            cart.Clear();
            return RedirectToAction("ShowProducts", "Product");
        }
    }
}