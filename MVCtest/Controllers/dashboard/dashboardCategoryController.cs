using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.dashboard
{
    public class dashboardCategoryController : Controller
    {

        CategoryService categorytService;
        // GET: dashboardCategory
        public ActionResult Index(CategoryViewModel input)
        {
            CategoryService cs = new CategoryService();
            //CategoryListViewModel result = csv.GetAllCategory();


            //CustomerViewModel cvm = new CustomerViewModel();
            //cvm.Customer_ID = input.Customer_ID;
            CategoryViewModel csv = new CategoryViewModel();
            csv.Category_Id = input.Category_Id;
            csv.Category_Name = input.Category_Name;
            
            if (cs.Create(csv))
            {
                TempData["message"] = "註冊成功";
                return RedirectToAction("index", "dashboardCategory");
            }
            else
            {
                TempData["message"] = "註冊失敗";
                return RedirectToAction("index", "dashboardCategory");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateSub()
        {
            return View();
        }

    
    }
}