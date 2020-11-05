using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace WebApplication.App_Code
{
    public class MyRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            
            
            return new HandlerMVC(requestContext);
        }
    }

    //public class MyHandlerMVC : IHttpHandler
    //{
    //    public bool IsReusable { get { return false; } }

    //    public void ProcessRequest(HttpContext context)
    //    {
    //        context.Response.Write("MVC hendler");
    //    }
    //}
}