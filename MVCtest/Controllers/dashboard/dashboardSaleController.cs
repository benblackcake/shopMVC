using MVCtest.Fiter;
using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.dashboard
{
    public class dashboardSaleController : Controller
    {
        [AuthorizeMaster]
        // GET: dashboardSale
        public ActionResult Index()
        {
            return View();
        }

        [Route("api/dashboardSale/GetSale")]
        public JsonResult GetSale()
        {
            SaleService os = new SaleService();
            SaleListViewModel result = os.GetAllSale();
            
           var datas = new { result.data };
            return Json(datas, JsonRequestBehavior.AllowGet);
        }
    }
}