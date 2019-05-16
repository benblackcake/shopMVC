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
        [ValidateAntiForgeryToken]
        public ActionResult CartSave(string productName,int quantity)
        {
            cartService.SaveCartDB(productName,quantity);
            return View(cartService.GetListCart());
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Cart()
        {
            cartService = new CartService();
            return View(cartService.GetListCart());
        }
    }
}