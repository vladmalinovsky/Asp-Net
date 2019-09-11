using StoreCar.Models;
using System;
using System.Web.Mvc;


namespace StoreCar.Binders
{
    public class CartModelBinder : System.Web.Mvc.IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext
       bindingContext)
        {
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
                    
        if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            
            return cart;
        }
    }
}