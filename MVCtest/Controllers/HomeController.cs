using MVCtest.Fiter;
using MVCtest.Models;
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
        //[AuthorizePlus]
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

        [AuthorizePlus]
        public ActionResult memberlist()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Updatemember(Customer input)
        {
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.Customer_Email = input.Customer_Email;
            cvm.Customer_Name = input.Customer_Name;
            string pwd = Helper.EncodePassword(input.User_Password);
            cvm.User_Password = pwd;
            cvm.Customer_Phone = input.Customer_Phone;
            CustomerService service = new CustomerService();
            Debug.Print(cvm.Customer_Email);
            Debug.Print(cvm.Customer_Name);
            Debug.Print(cvm.User_Password);
            Debug.Print(cvm.Customer_Phone);

            input.User_Password = Helper.EncodePassword(input.User_Password);

            if (service.Update(input))
            {
                TempData["message"] = "修改成功";
                return RedirectToAction("index", "MemberCenter");
            }
            else
            {
                TempData["message"] = "修改失敗";
                return RedirectToAction("index", "MemberCenter");
            }
        }
    }
}