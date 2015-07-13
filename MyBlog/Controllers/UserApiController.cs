using PersonalCMS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlog.Controllers
{
    public class UserApiController : ApiController
    {
        private IUserService userService;
        public UserApiController(IUserService userService)
        {
            this.userService = userService;
        }

        public string Get()
        {
            return "hello world";
        }
    }
}
