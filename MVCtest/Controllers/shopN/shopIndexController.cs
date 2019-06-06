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
    public class shopIndexController : Controller
    {
        // GET: shopIndex
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            ProductService ps = new ProductService();
            ProductListViewModel psv = ps.GetProducts();
            foreach (var i in psv.Items)
            {
                Debug.Print(i.Product_Image);
            }
            return View(psv);
        }
    }
}