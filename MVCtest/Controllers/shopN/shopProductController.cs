using MVCtest.Models;
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
        public ActionResult Index(string Product_NAME)
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
            if (Product_NAME == null)
            {
                foreach (var i in Request.QueryString.AllKeys.ToList())
                {
                    Debug.Print(i);
                    switch (i)
                    {
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
            else
            {
                int SearchProduct_Id;
                using (DBModel db = new DBModel())
                {
                    SearchProduct_Id = (from s in db.Products
                                        where s.Product_Name == Product_NAME
                                        select s.Product_Id).FirstOrDefault();
                }
                if (SearchProduct_Id != null)
                {
                    using (DBModel db = new DBModel())
                    {
                        var result = (from s in db.Products
                                      where s.Product_Id == SearchProduct_Id
                                      select s).ToList();
                    }
                    psv = ps.SearchProducts(Product_NAME);
                    return View(psv);
                }
                return View();
            }


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