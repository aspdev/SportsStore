using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using IModelBinder = System.Web.ModelBinding.IModelBinder;
using ModelBindingContext = System.Web.ModelBinding.ModelBindingContext;

namespace SportsStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : System.Web.Mvc.IModelBinder
    {
        private const string SessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
            System.Web.Mvc.ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart) controllerContext.HttpContext.Session[SessionKey];
            }

            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = cart;
                }
            }

            return cart;
        }
    }
}