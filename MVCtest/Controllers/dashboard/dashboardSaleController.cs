using MVCtest.Fiter;
using MVCtest.Models;
using MVCtest.Repository;
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
        private DBModel db = new DBModel();

        private Dictionary<string, string> GetAllProductName()
        {
            var query = db.Product.OrderBy(x => x.Product_Id);
            return query.ToDictionary(x => x.Product_Id.ToString(), x => x.Product_Name);
        }


        [AuthorizeMaster]
        // GET: dashboardSale
        public ActionResult Index()
        {
            DBModel contex = new DBModel();
            DbRepository<Product> repo = new DbRepository<Product>(contex);
            var name = repo.GetAll().OrderBy(x => x.Product_Id).ToList();
            ViewBag.Sale_Product = new SelectList
                (
                  items: name,
                  dataTextField:"Product_Name",
                  dataValueField: "Product_Name"
                );
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
        [HttpPost]
        public ActionResult Create(SaleViewModel input)
        {
            SaleViewModel cvm = new SaleViewModel();
            cvm.Sale_Product = input.Sale_Product;
            cvm.Sale_UnPrice = input.Sale_UnPrice;
            cvm.Sale_FristDate = input.Sale_FristDate;
            cvm.Sale_LastDate = input.Sale_LastDate;
            SaleService service = new SaleService();
            if (cvm.Sale_Product==input.Sale_Product)
            {


                TempData["message"] = "有此產品了";
                return RedirectToAction("Index", "dashboardSale");
            }
            else
            {
                service.Create(cvm);
                return RedirectToAction("Index", "dashboardSale");
            }


        }

    }
}