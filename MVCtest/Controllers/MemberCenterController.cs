using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCtest.Fiter;
using MVCtest.Models;
using MVCtest.Service;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class MemberCenterController : Controller
    {
        private const string XsrfKey = "XsrfId";
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        // GET: MemberCenter
        //[AuthorizePlus]
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
            cvm.Customer_Email = input.Customer_Email;
            cvm.Customer_Name = input.Customer_Name;
            cvm.User_Password = Helper.EncodePassword(input.User_Password);
            cvm.Customer_Phone = input.Customer_Phone;
            CustomerService service = new CustomerService();
            if (service.Create(cvm))
            {
                TempData["message"] = "註冊成功";
                return RedirectToAction("index", "MemberCenter");
            }
            else
            {
                TempData["message"] = "註冊失敗";
                return RedirectToAction("index", "MemberCenter");
            }

            Debug.WriteLine(input.Customer_Email.ToString());
            Debug.WriteLine(Helper.EncodePassword(input.User_Password)); 
            Debug.WriteLine("POST");
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
            CustomerViewModel cvm = cs.GetMember(login.Customer_Email, login.User_Password);
            if (cvm != null){
                Debug.Print(cvm.Customer_Name);
                string email = cvm.Customer_Email;
                string name = cvm.Customer_Name;//這邊幫你註改了你再看一下~~~~
                int id = cvm.Customer_ID;
                Debug.WriteLine(name);
                
                Session["auth"] = true;
                Session["Name"] = name;
                Session["Email"] = email;
                Session["ID"]= id;
                TempData["message"] = "登入成功。";
                return RedirectToAction("index", "Home");

            }else{
                TempData["message"] = "帳號密碼錯誤。登入失敗";
                return RedirectToAction("index", "MemberCenter");
            }

        }



        public ActionResult Logout ()
        {
            Debug.Print("GET");
            Session["auth"] = false;
            Session["Name"] = "Logout";
            TempData["message"] = "登出成功。";
            return RedirectToAction("index", "MemberCenter");

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // 要求重新導向至外部登入提供者
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "MemberCenter", new { ReturnUrl = returnUrl }));
        }



        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            //if (loginInfo == null) {
            //    return RedirectToAction("Login");
            //}

            //// 若使用者已經有登入資料，請使用此外部登入提供者登入使用者
            //var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            //switch (result) {
            //    case SignInStatus.Success:

            //        //return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
            //    case SignInStatus.Failure:
            //    default:
            //        // 若使用者沒有帳戶，請提示使用者建立帳戶
            //        ViewBag.ReturnUrl = returnUrl;
            //        ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
            //        Debug.Print("callback____DEBUG____");
                    
            //}

            Debug.Print("callback____DEBUG__SUCCESS__");

            CustomerService cs = new CustomerService();
            CustomerViewModel cvm = cs.GetFbMember(loginInfo.Email, loginInfo.DefaultUserName);
            if (cvm != null) {
                Debug.Print(cvm.Customer_Name);
                string email = cvm.Customer_Email;
                string name = cvm.Customer_Name;//這邊幫你註改了你再看一下~~~~
                int id = cvm.Customer_ID;
                Debug.WriteLine(name);

                Session["auth"] = true;
                Session["Name"] = name;
                Session["Email"] = email;
                Session["ID"] = id;
                TempData["message"] = "登入成功。";
                return RedirectToAction("index", "Home");

            } else {

                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName, Email = loginInfo.Email });
            }
        }


        //
        //POST: /Account/ExternalLoginConfirmation
       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            Debug.Print("ExternalLoginConfirmation____DEBUG____");

            //if (User.Identity.IsAuthenticated) {
            //    return RedirectToAction("Index", "Manage");
            //}

            //if (ModelState.IsValid) {
                // 從外部登入提供者處取得使用者資訊
                //var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                //if (info == null) {
                //    return View("ExternalLoginFailure");
                //}
                //var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                //var result = await UserManager.CreateAsync(user);
                //if (result.Succeeded) {
                //    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                //    if (result.Succeeded) {
                //        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                //        return RedirectToLocal(returnUrl);
                //    }
                //}
                //AddErrors(result);
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null) {
                    return View("ExternalLoginFailure");
                }
                CustomerViewModel cvm = new CustomerViewModel();
                cvm.Customer_Email = model.Email;
                cvm.Customer_Name = model.UserName;
                CustomerService service = new CustomerService();
                if (service.Create(cvm)) {
                    TempData["message"] = "註冊成功";
                    return RedirectToAction("index", "MemberCenter");
                } else {
                    TempData["message"] = "註冊失敗";
                    return RedirectToAction("index", "MemberCenter");
                }
            //}

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }



        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null) {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
    }
}