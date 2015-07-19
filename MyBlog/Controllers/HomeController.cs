using MyBlog.Filters;
using PersonalCMS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    [BlogAuthorize]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.UserName = UserSessionModel.GetCurrentUser().Name;
            var dto = userService.Get();
            return View(dto);
        }
    }
}