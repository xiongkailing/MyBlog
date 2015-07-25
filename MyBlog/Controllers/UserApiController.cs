using MyBlog.Filters;
using MyBlog.Models.ApiModels;
using PersonalCMS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        ///方法一：
        //public HttpResponseMessage Get()
        //{
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "helloword");
        //    //response.Headers.Add("Access-Control-Allow-Origin", "*");
        //    //response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        //    response.Content = new StringContent("hello world", Encoding.Unicode);
        //    response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
        //    {
        //        MaxAge = TimeSpan.FromMinutes(20)
        //    };
        //    return response;
        //}

        /// <summary>
        /// 方法二
        /// </summary>
        /// <returns></returns>
        //[EnableCorsAccess]
        //public string Get()
        //{
        //    return "hello world";
        //}

        /// <summary>
        /// 方法三 同方法一 使用IHttpActionResult的工厂方法
        /// </summary>
        /// <returns>Teststrings</returns>
        public IHttpActionResult Get()
        {
            return new TextResult("hello", Request);
        }
    }
}
