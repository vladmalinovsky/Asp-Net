﻿using StoreLayer.WEB.Models;
using StoreLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLayer.WEB.Binders
{
    public class CartModelBinder : System.Web.Mvc.IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext
       bindingContext)
        {
            CartDTO cart = (CartDTO)controllerContext.HttpContext.Session[sessionKey];

            if (cart == null)
            {
                cart = new CartDTO();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            return cart;
       }
    }
}