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

        //public ActionResult membercenter()
        //{
        //    Debug.WriteLine("GET");

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult membercenter(CustomerViewModel input)
        //{
        //    Debug.WriteLine(input.Customer_E_mail.ToString());
        //    CustomerViewModel cvm = new CustomerViewModel();

        //    //cvm.Customer_ID = input.Customer_ID;
        //    cvm.Customer_E_mail = input.Customer_E_mail;
        //    cvm.Customer_Name = input.Customer_Name;
        //    cvm.User_Password = Helper.EncodePassword(input.User_Password);
        //    CustomerService service = new CustomerService();
        //    service.Create(cvm);

        //    Debug.WriteLine(Helper.EncodePassword(input.User_Password));
        //    Debug.WriteLine("POST");

        //    return View();
        //}

        public ActionResult center()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult item()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult memberlist()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}