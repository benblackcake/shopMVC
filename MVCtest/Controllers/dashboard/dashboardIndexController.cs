using MVCtest.Fiter;
using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers.dashboard
{
    public class dashboardIndexController : Controller
    {
        // GET: dashboardIndex
        [AuthorizeMaster]
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(MasterViewModel login)
        {
            MasterService cs = new MasterService();
            MasterViewModel cvm = cs.GetMember(login.master_account, login.master_password);
            if (cvm != null)
            {
                
                string account = cvm.master_account;
                Debug.Print(account);
                Session["master_auth"] = true;
                Session["Name"] = account;
                //TempData["message"] = "登入成功。";
                return RedirectToAction("index", "dashboardProduct");

            }
            else
            {
                TempData["message"] = "帳號密碼錯誤。登入失敗";
                return RedirectToAction("index", "dashboardIndex");
            }

        }
        [Route("api/dashboardIndex/GetMaster")]
        public JsonResult GetMaster()
        {
            MasterService os = new MasterService();
            MasterListViewModel result = os.GetAllMaster();

            var datas = new { result.data };
            return Json(datas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            
            Session["master_auth"] = false;
            return RedirectToAction("index", "dashboardIndex");

        }

        [HttpPost]
        public ActionResult Register(MasterViewModel input)
        {
            MasterViewModel cvm = new MasterViewModel();
            cvm.master_account = input.master_account;
            cvm.master_password = input.master_password;
            MasterService service = new MasterService();
            if (service.Create(cvm))
            {
                TempData["message"] = "註冊成功";
                return RedirectToAction("Index", "dashboardIndex");
            }
            else
            {
                TempData["message"] = "註冊失敗";
                return RedirectToAction("Index", "dashboardIndex");
            }


        }

    }
}