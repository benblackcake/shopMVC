﻿using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.dashboard
{
    public class dashboardCustomerController : Controller
    {
        [Route("api/dashboardCustomer/GetCustomer")]
        public JsonResult GetCustomer()
        {
            CustomerService os = new CustomerService();
            CustomerListViewModel result = os.GetAllCustomer();

            var datas = new { result.Items };
            return Json(datas, JsonRequestBehavior.AllowGet);
        }
        // GET: dashboardCustomer
        public ActionResult Index()
        {
            return View();
        }
    }
}