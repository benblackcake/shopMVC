using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.dashboard
{
    public class dashboardCustomerController : Controller
    {

        public JsonResult GetChart()
        {
            List<int> id = new List<int>();
            List<string> email = new List<string>();
            List<string> name = new List<string>();
            List<string> phone = new List<string>();
            CustomerService os = new CustomerService();
            CustomerListViewModel result = os.GetAllCustomer();
            foreach (var item in result.Items)
            {
                id.Add(item.Customer_ID);
                email.Add(item.Customer_Email);
                name.Add(item.Customer_Name);
                phone.Add(item.Customer_Phone);
            }


            var datas = new { id, email,name,phone };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: dashboardCustomer
        public ActionResult Index()
        {
            return View();
        }
    }
}