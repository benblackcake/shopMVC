using MVCtest.Fiter;
using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizePlus]
        public ActionResult Index()
        {
            ProductService ps = new ProductService();
            ProductListViewModel psv = ps.GetProducts();
            foreach (var i in psv.Items)
            {
                Debug.Print(i.Product_Image);
            }
            return View(psv);
        }

        public ActionResult item()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AuthorizePlus]
        public ActionResult memberlist()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}