using MVCtest.Fiter;
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

        //API GET :/dashboardMember/getTopSale
        [Route("api/dashboardMember/GetTopSale")]
        public JsonResult getTopSale()
        {
            List<string> label = new List<string>();
            List<int> data = new List<int>();

            ProductService ps = new ProductService();
            TopSaleListViewModel result = ps.GetTopSale();


            foreach (var item in result.Item) {
                label.Add(item.Product_Name.Replace(" ","").ToString());
                data.Add(item.Quantity);
            }
            var datas = new { label, data };
            //var datas = new { psv.data };
            return Json(datas, JsonRequestBehavior.AllowGet);
        }

        //API GET :/dashboardMember/getSum
        [Route("api/dashboardMember/GetSum")]
        public JsonResult GetSum()
        {
            ProductService ps = new ProductService();
            List<int> datas = ps.GetTotalSum();
            
            var d = new { datas };
            return Json(d, JsonRequestBehavior.AllowGet);
        }
        // view 
        [AuthorizeMaster]
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


        [AuthorizeMaster]
        public ActionResult createProduct()
        {

            return View();
        }

    }
}