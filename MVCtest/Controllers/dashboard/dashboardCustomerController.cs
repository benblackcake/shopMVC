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
        [Route("api/dashboardCustomer/GetCustomer")]
        public JsonResult GetCustomer()
        {
            CustomerService os = new CustomerService();
            CustomerListViewModel result = os.GetAllCustomer();

            var datas = new { result.data };
            return Json(datas, JsonRequestBehavior.AllowGet);
        }

        [Route("api/dashboardCustomer/GetDateCustomer")]
        public JsonResult GetDateCustomer()
        {
            List<string> label = new List<string>();
            List<int> data = new List<int>();

            CustomerService os = new CustomerService();
            CustomerDateListViewModel result = os.GetDateCustomer();
            foreach (var item in result.Item) {
                label.Add(item.Month.ToString() + "月");
                data.Add(item.Quantity);
            }
            var datas = new { label, data };

            return Json(datas, JsonRequestBehavior.AllowGet);
        }
        // GET: dashboardCustomer
        public ActionResult Index()
        {
            return View();
        }
    }
}