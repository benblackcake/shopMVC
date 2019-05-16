using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCtest.Service;
using MVCtest.ViewModels;

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
            return View();
        }
        [HttpGet]
        public ActionResult Cart()
        {
            
            int id = int.Parse(HttpContext.Session["id"].ToString());
            cartService = new CartService();
            return View(cartService.GetListCart(id));
        }   
        public ActionResult DeleteCart(int cartID)
        {

            cartService = new CartService();
            cartService.Delete(cartID);
            return RedirectToAction("Cart");
        }
    }
}