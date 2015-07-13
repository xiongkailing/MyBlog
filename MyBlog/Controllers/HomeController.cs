using PersonalCMS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
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
            var dto = userService.Get();
            return View(dto);
        }
    }
}