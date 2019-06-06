using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.shopN
{
    public class shopProductController : Controller
    {
        // GET: shopProduct
        [HttpGet]
        // GET: Product
        public ActionResult Index()
        {
            ProductService ps = new ProductService();
            ProductListViewModel psv;
            //if (Request.QueryString["category"] != null)
            //{
            //    psv = ps.GetCategoryProduct(int.Parse(Request.QueryString["category"]));
            //    Debug.Print(psv.Items.Count().ToString());
            //}
            //else psv = ps.GetProducts();
            //Debug.Print(Request.QueryString.AllKeys);
            foreach (var i in Request.QueryString.AllKeys.ToList()) {
                Debug.Print(i);
                switch (i) {
                    case "category":
                        psv = ps.GetCategoryProduct(int.Parse(Request.QueryString["category"]));
                        Debug.Print("catrgory");
                        break;

                    case "subcategory":
                        psv = ps.GetSubCategoryProduct(int.Parse(Request.QueryString["subcategory"]));
                        Debug.Print("subcatrgory");
                        break;
                    default:
                        psv = ps.GetProducts();
                        break;
                        //    return View(psv);
                }
                return View(psv);

            }
            psv = ps.GetProducts();
            return View(psv);

        }

        [HttpGet]
        public ActionResult detail(int id)
        {
            ProductService ps = new ProductService();
            ProductViewModel result = ps.GetProductDetail(id);
            //ViewBag.Message = "Your contact page.";
            Debug.Print(id.ToString());
            return View(result);
        }

    }
}