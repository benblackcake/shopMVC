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
    public class ProductController : Controller
    {
        [AuthorizePlus]
        [HttpGet]
        // GET: Product
        public ActionResult Index()
        {
            ProductService ps = new ProductService();
            ProductListViewModel psv = ps.GetProducts();
            return View(psv);
        }
        [HttpGet]
        public ActionResult detail(int id)
        {
            ProductService ps = new ProductService();
            ProductViewModel result = ps.GetProductDetail(id);
            ViewBag.Message = "Your contact page.";
            Debug.Print(id.ToString());
            return View(result);
        }

    }
}