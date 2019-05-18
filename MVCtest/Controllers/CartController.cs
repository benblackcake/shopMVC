using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCtest.Service;
using MVCtest.ViewModels;
using MVCtest.Fiter;

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
        [AuthorizePlus]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Cart(int productId,int quantity)
        {
            if (Helper.CheckSession(HttpContext))
            {
                int id = Helper.ID;
                CartService cs = new CartService();
                cs.SaveCartDB(productId, id, quantity);
                return View(cs.GetListCart(id));
            }
            else return View();

        }
        [AuthorizePlus]
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
        [AuthorizePlus]
        [HttpPost]
        public ActionResult DeleteCart(int cartID)
        {
            cartService = new CartService();
            cartService.Delete(cartID);
            return RedirectToAction("Cart");

        }
    }
}