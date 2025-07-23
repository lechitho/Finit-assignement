using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Test.Helpers
{
    public static class HttpContextHelper
    {
        public static HttpContext GetHttpContext()
        {
            var context = new DefaultHttpContext();
            context.Request.Scheme = "http";
            context.Request.Host = new HostString("my.HoΨst:80");
            context.Request.PathBase = new PathString("/un?escaped/base");
            context.Request.Path = new PathString("/un?escaped");
            context.Request.QueryString = new QueryString("?name=val%23ue");

            return context;

        }
    }
}
