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
        //CartService cartService ;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CartSave(string productName,int quantity)
        {
            CartService cs = new CartService();
            cs.SaveCartDB(productName,quantity);
            return View();
        }
        [HttpGet]
        public ActionResult Cart()
        {
            CartService cs = new CartService();
            int id = int.Parse(HttpContext.Session["id"].ToString());

            return View(cs.GetListCart(id));
        }

        //[HttpPost]
        //public ActionResult Delete(int CartId)
        //{
        //    CartService cs = new CartService();
        //    int cusID = int.Parse(HttpContext.Session["id"].ToString());
        //    cs = new CartService();
        //    cs.DeleteCart(CartId);
        //    Debug.Print(CartId.ToString());
        //    return RedirectToAction("Cart", "Cart");

        //    cartService = new CartService();
        //    return View(cartService.GetListCart(id));
        //}   
        [HttpPost]
        public ActionResult DeleteCart(int cartID)
        {
            cartService = new CartService();
            cartService.Delete(cartID);
            return RedirectToAction("Cart");

        }
    }
}