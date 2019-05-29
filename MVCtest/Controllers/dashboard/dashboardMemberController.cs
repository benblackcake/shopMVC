using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.dashboard
{
    public class dashboardMemberController : Controller
    {
        // GET: dashboardMember
        public JsonResult GetChart()
        {
            List<string> label = new List<string>();
            List<int> data = new List<int>();
            OrderService os = new OrderService();
            SaleQuantityListViewModel result=os.GetSaleQuantity();
            foreach (var item in result.Item) {
                label.Add(item.Month.ToString()+"月");
                data.Add(item.Quantity);
            }
            

            var datas = new { label,data };

            return Json(datas, JsonRequestBehavior.AllowGet);
        }
        // GET: dashboardMember 
        public ActionResult Index()
        {            

            return View();
        }

        public ActionResult category()
        {
            CategoryService csv = new CategoryService();
            CategoryListViewModel result = csv.GetAllCategory();
            return View(result);
        }


    }
}