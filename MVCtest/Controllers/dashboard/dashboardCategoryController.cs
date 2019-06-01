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
        public ActionResult Index()
        {
            CategoryService csv = new CategoryService();
            CategoryListViewModel result = csv.GetAllCategory();
            
            return View(result);
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