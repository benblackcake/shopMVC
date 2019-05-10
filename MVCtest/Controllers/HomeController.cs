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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult membercenter()
        {
            Debug.WriteLine("GET");
            
            return View();
        }

        [HttpPost]
        public ActionResult membercenter(CustomerViewModel input)
        {
            Debug.WriteLine(input.Customer_E_mail.ToString());
            CustomerViewModel cvm = new CustomerViewModel();

            cvm.Customer_ID = input.Customer_ID;
            cvm.Customer_E_mail = input.Customer_E_mail;

            CustomerService service = new CustomerService();
            service.Create(cvm);

            Debug.WriteLine("POST");
            
            return View();
        }
    }
}