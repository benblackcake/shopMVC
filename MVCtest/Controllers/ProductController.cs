using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductService ps = new ProductService();
            ProductListViewModel psv = ps.GetProducts();
            return View(psv);
        }
        public ActionResult CategoriesFilter(string checkList1Value)
        {
            FilterService filterService = new FilterService();
            var viewModel = new List<ProductViewModel>();
            viewModel = filterService.CategoriesFilter(checkList1Value);
            return View(viewModel);
        }

    }
}