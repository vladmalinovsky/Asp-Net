using StoreLayer.WEB.Models;
using StoreLayerApp.BLL.DTO;
using System.Web.Mvc;
using StoreLayerApp.BLL.Interfaces;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace StoreLayer.WEB.Controllers
{
    public class CartController : Controller
    {
        IProductService productService;
        ICartService cartService;

        public CartController(IProductService serv, ICartService sv)
        {
            productService = serv;
            cartService = sv;
        }

        public ViewResult Index(CartDTO cart)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart
            });
        }

        public RedirectToRouteResult AddToCart(CartDTO cart, int productId)
        {
            ProductDTO productDTO = productService.getProduct(productId);
            cart.AddItem(productDTO, 1);
            return RedirectToAction("Index", "Cart");
        }

        public RedirectToRouteResult RemoveFromCart(CartDTO cart, int productId)
        {
            ProductDTO productDTO = productService.getProduct(productId);
            cart.RemoveLine(productDTO);
            return RedirectToAction("Index", "Cart");
        }

        public RedirectToRouteResult Checkout(CartDTO cart)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            cart.UserName = User.Identity.GetUserName().ToString();
            cartService.Checkout(cart);
            cart.Clear();
            return RedirectToAction("Index", "Product");
        }
    }
}