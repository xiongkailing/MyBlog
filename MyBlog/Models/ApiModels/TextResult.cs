using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyBlog.Models.ApiModels
{
    public class TextResult : IHttpActionResult
    {
        private string _text;
        private HttpRequestMessage _request;
        public TextResult(string value, HttpRequestMessage request)
        {
            _text = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_text),
                RequestMessage = _request
            };
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            return Task.FromResult(response);
        }

    }
}