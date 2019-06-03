﻿using MVCtest.Service;
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
        // GET: dashboardCategory'

        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        public ActionResult Index(/*CategoryViewModel input*/)
        {

            CategoryService cs = new CategoryService();
            CategoryListViewModel result = cs.GetAllCategory();


            return View(result);
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel input)
        {
            CategoryService cs = new CategoryService();
            CategoryViewModel csv = new CategoryViewModel();
            //csv.Category_Id = input.Category_Id;
            csv.Category_Name = input.Category_Name;

            if (cs.Create(csv))
            {
                TempData["message"] = "新增成功";
                return RedirectToAction("Index", "dashboardCategory");
            }
            else
            {
                TempData["message"] = "新增失敗";
                return RedirectToAction("Index", "dashboardCategory");
            }

        }

        public ActionResult CreateSub()
        {
            return View();
        }

    
    }
}