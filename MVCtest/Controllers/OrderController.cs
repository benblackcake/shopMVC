using MVCtest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {

            return View();
        }
        //[HttpGet]
        //public ActionResult History_order()
        //{
        //    OrderService cs = new OrderService();
        //    int id = (int)Session["id"];

        //    return View(cs.GetListOrder(id));
        //}
    }
}