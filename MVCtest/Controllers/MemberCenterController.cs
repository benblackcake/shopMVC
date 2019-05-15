﻿using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class MemberCenterController : Controller
    {
        // GET: MemberCenter
        public ActionResult index()
        {
            Debug.WriteLine("GET");

            return View();
        }

        [HttpPost]
        public ActionResult index(CustomerViewModel input)
        {
            CustomerViewModel cvm = new CustomerViewModel();
            //cvm.Customer_ID = input.Customer_ID;
            cvm.Customer_E_mail = input.Customer_E_mail;
            cvm.Customer_Name = input.Customer_Name;
            cvm.User_Password = Helper.EncodePassword(input.User_Password);
            CustomerService service = new CustomerService();
            service.Create(cvm);

            Debug.WriteLine(input.Customer_E_mail.ToString());
            Debug.WriteLine(Helper.EncodePassword(input.User_Password));
            Debug.WriteLine("POST");

            return View();
        }
        [HttpPost]
        public ActionResult login(CustomerViewModel login)
        {

            //cvm.Customer_E_mail = login.Customer_E_mail;
            //cvm.User_Password = Helper.EncodePassword(login.User_Password);
            //LoginService service = new LoginService();
            //if(cvm.Customer_E_mail==login.Customer_E_mail&&cvm.User_Password==Helper.EncodePassword(login.User_Password))
            //{
            //    TempData["message"] = "登入成功";
            //    Debug.WriteLine("POST");
            //    return RedirectToAction("index", "MemberCenter");

            //}
            //else
            //{
            //    TempData["message"] = "帳號密碼錯誤。登入失敗";
            //    Debug.WriteLine("POST");
            //    return RedirectToAction("index", "MemberCenter");
            //}  
            CustomerService cs = new CustomerService();

            CustomerViewModel cvm = cs.GetMember(login.Customer_E_mail, login.User_Password);
            if (cvm != null){
                Debug.Print(cvm.Customer_Name);

                string name = cvm.Customer_Name;//這邊幫你註改了你再看一下~~~~
                Session["Name"] = name;
                Debug.WriteLine(name);

                TempData["message"] = "登入成功";
                return RedirectToAction("index", "MemberCenter");

            }else{
                TempData["message"] = "帳號密碼錯誤。登入失敗";
                return RedirectToAction("index", "MemberCenter");
            }

        }

    }
}