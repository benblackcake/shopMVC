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
            OrderService os = new OrderService();
            SaleQuantityListViewModel result=os.GetSaleQuantity();

            

            var data = new { Name = "kevin", Age = 40 };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: dashboardMember 
        public ActionResult Index()
        {
            
            return View();
        }
    }
}