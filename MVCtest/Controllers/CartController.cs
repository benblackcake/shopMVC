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
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cart(string productName,int quantity)
        {
            CartService cartService = new CartService();
            cartService.SaveCartDB(productName,quantity);
            return View(cartService.GetListCart());
        }
    }
}