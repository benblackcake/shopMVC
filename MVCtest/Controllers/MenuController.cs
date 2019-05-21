using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Category()
        {
            CategoryService csv = new CategoryService();
            CategoryListViewModel result = csv.GetAllCategory();
            
            return PartialView(result);
        }
        public ActionResult SideCategory()
        {
            CategoryService csv = new CategoryService();
            CategoryListViewModel result = csv.GetAllCategory();
            return PartialView(result);
        }
        //public ActionResult SubCategory()
        //{
        //    CategoryService csv = new CategoryService();
        //    CategoryListViewModel result = csv.GetAllCategory();
        //    return PartialView(result);
        //}
    }
}