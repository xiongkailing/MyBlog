using MyBlog.Filters;
using MyBlog.Models.Account;
using PersonalCMS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            //TODO:验证model 
            var query = userService.Login(model.Name.Trim(), model.Password.Trim());
            if (query == null)
            {
                if (Request.IsAjaxRequest())
                    return Json(new { Message = "验证失败" }, JsonRequestBehavior.AllowGet);//避免Ajax登入时无响应
                else
                {
                    ModelState.AddModelError("", "");
                    return View();
                }
            }
            else
            {
                //add cookie
                JavaScriptSerializer js = new JavaScriptSerializer();
                UserSessionModel sessionModel = new UserSessionModel { Id = query.Id, Name = query.NickName };
                var cookie = new HttpCookie("AccountInfo");
                cookie.Value = js.Serialize(sessionModel);
                //cookie.Secure = true;//这个要在SSL下才能生效 否者传不过去  
                cookie.Expires = model.IsRemember ? DateTime.Now.AddDays(7) : DateTime.Now.AddHours(30);
                Response.Cookies.Remove("AccountInfo");
                Response.AppendCookie(cookie);
                if (Request.IsAjaxRequest())
                    return Json(new { Message = "登入成功" }, JsonRequestBehavior.AllowGet);
                else
                    return Redirect(returnUrl);
            }
        }
    }
}