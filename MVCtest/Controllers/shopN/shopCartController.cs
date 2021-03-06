﻿using MVCtest.Fiter;
using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.shopN
{
    public class shopCartController : Controller
    {
        CartService cartService;
        // GET: shopCart
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizePlus]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Cart(int productId, int quantity,string color,string size)
        {
            int id = (int)Session["id"];
            CartService cs = new CartService();
            cs.SaveCartDB(productId, id, quantity,color,size);
            return RedirectToAction("Cart");
        }

        [AuthorizePlus]
        [HttpGet]
        public ActionResult Cart()
        {
            CartService cs = new CartService();
            int id = (int)Session["id"];

            return View(cs.GetListCart(id));
        }

        [AuthorizePlus]
        [HttpPost]
        public ActionResult SaveOrder(string paymentID, string shipperID ,string recipient_Name ,string recipient_Phone ,string recipient_Address)
        {
            CartService cs = new CartService();
            int id = (int)Session["id"];
            cs.SaveOrder(id, paymentID, shipperID,recipient_Name,recipient_Phone,recipient_Address);
            return RedirectToAction("history_order","Home");
        }

        [AuthorizePlus]
        [HttpPost]
        public ActionResult DeleteCart(int cartID)
        {
            cartService = new CartService();
            cartService.Delete(cartID);
            return RedirectToAction("Cart");

        }


        [AuthorizePlus]
        [HttpPost]
        public ActionResult UpdateQuantity(int cartID, string quantity)
        {
            cartService = new CartService();
            cartService.UpdateQuantity(cartID, quantity);

            return View();
        }
    }
}