using StoreCar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreCar.Controllers
{
    public class ProductController : Controller
    {
        StoreCarDB db = new StoreCarDB();

        // GET: Product
        [Authorize(Roles = "admin")]
        public ActionResult CreateProduct()
        {
            return View(new Product());
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return Redirect("/Product/ShowProducts");
        }

        [Authorize(Roles = "admin, manager")]
        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db.Products.Find(id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "admin,manager")]
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Product/ShowProducts");
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            
            db.Products.Remove(product);
            db.SaveChanges();
            return Redirect("/Product/ShowProducts");
        }

        public ActionResult ShowProducts()
        {
            var products = db.Products;
            return View(products.ToList());
        }
                       
       
    }
}