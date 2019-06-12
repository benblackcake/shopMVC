using MVCtest.Fiter;
using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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


        [HttpPost]
        public ActionResult createProduct(ProductViewModel pvm){
            try {
                ProductViewModel pvmm = new ProductViewModel();
                var httprequest = HttpContext.Request;
                string filename = null;
                foreach (string file in httprequest.Files) {
                    var postfile = httprequest.Files[file];
                    if(postfile != null && postfile.ContentLength > 0) {
                        Debug.Print("upload");
                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  
                        List<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postfile.FileName.Substring(postfile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension)) {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");


                            return Json("Please Upload image of type .jpg,.gif,.png.");
                        } else if (postfile.ContentLength > MaxContentLength) {
                            return Json("Please Upload a file upto 1 mb.");
                        } else {



                            var filePath = HttpContext.Server.MapPath("/Assest/images/c/" + postfile.FileName);

                            postfile.SaveAs(filePath);

                        }
                    }
                    //filename = postfile.FileName.Substring(postfile.FileName.LastIndexOf('.'));
                    filename = postfile.FileName.ToLower();
                }

                pvmm.Product_Name = pvm.Product_Name;
                pvmm.UnitPrice = pvm.UnitPrice;
                pvmm.Sub_Category_Name = pvm.Sub_Category_Name;
                pvmm.CategoryGroup_Name = pvm.CategoryGroup_Name;

                pvmm.Product_Image = pvm.Product_Image;
                Debug.Print(pvmm.Product_Name);
                Debug.Print(pvmm.UnitPrice);
                Debug.Print(pvmm.Sub_Category_Name);
                Debug.Print(pvmm.Product_Image);

            } catch (Exception e) {


            }


            return View();
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