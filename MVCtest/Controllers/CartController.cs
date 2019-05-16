using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCtest.Service;

namespace MVCtest.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        CartService cartService ;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CartSave(string productName,int quantity)
        {
            cartService = new CartService();
            cartService.SaveCartDB(productName,quantity);
            return View(cartService.GetListCart());
        }
        public ActionResult Cart(string productName, int quantity)
        {
            cartService = new CartService();
            cartService.SaveCartDB(productName, quantity);
            return View(cartService.GetListCart());
        }
    }
}