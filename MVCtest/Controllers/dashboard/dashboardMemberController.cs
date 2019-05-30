using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.dashboard
{
    
    public class dashboardProductController : Controller
    {

        //API GET :/dashboardMember/GetChart
        [Route("api/dashboardMember/GetChart")]
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

        //新增商品
        //API POST :/dashboardMember/crateProduct
        [HttpPost]
        public JsonResult crateProduct(ProductViewModel pvm) {

            return null;
        }
        //API GET :/dashboardMember/getProduct
        [Route("api/dashboardMember/GetProduct")]
        public JsonResult getProduct(){
            ProductService ps = new ProductService();
            ProductListViewModel psv= ps.GetAllProduct();

            var datas = new { psv.data };
            return Json(datas, JsonRequestBehavior.AllowGet);
        }


        // view 
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult createProduct()
        {

            return View();
        }
    }
}