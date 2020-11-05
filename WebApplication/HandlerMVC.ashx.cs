using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using WebApplication.DI;
using WebApplication.Implementation;

namespace WebApplication
{

    /// <summary>
    /// Сводное описание для HandlerMVC
    /// </summary>
    public class HandlerMVC : IHttpHandler
    {
        RequestContext _requestContext;
        public HandlerMVC(RequestContext requestContext)
        {
            _requestContext = requestContext;
        }
        void TestMethod()
        {

        }
        private object GetController(Type type)
        {
            //tmp comment
            Type newObjectType=type;
            ConstructorInfo constructor;
            if (DiManager.Injections.ContainsKey(type))
            {
                newObjectType = DiManager.Injections[type];
                constructor = newObjectType.GetConstructors()[0];
            }
            else
            {
                constructor = type.GetConstructors()[0];
            }

            if (constructor.GetParameters().Length == 0)
            {
                object obj = Activator.CreateInstance(newObjectType);
                return obj;
            }
            ParameterInfo[] parameters = constructor.GetParameters();
            return Activator.CreateInstance(newObjectType, GetController(  parameters[0].ParameterType  ));
           
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Привет всем!");
            var tmp = _requestContext.HttpContext.Request.Path;
            var path = tmp.Split('/');
            int controllerIndex = 1, actionIndex=2;

            string controllerName = RouteConfig.Routes.SingleOrDefault(x => x.Key.ToLower() == path[controllerIndex].ToLower()).Value;
               
            string actionName =path[actionIndex];
            object result;
            Type controllerType = Type.GetType($"WebApplication.{controllerName}Controller", false, false);
            foreach (MethodInfo method in controllerType.GetMethods())
            {
                if (actionName.ToLower() == method.Name.ToLower())
                {
                    result = controllerType.GetMethod(method.Name).Invoke(GetController(controllerType), null);
                    context.Response.Write(result);
                }
            }
            /*switch (controllerName)
            {
                case "Index":
                    IndexController index =GetController(typeof(IndexController)) as IndexController;
                    //result = typeof(IndexController).GetMethod(actionName).Invoke(index, null);
                    //context.Response.Write(result);
                    foreach (MethodInfo method in typeof(IndexController).GetMethods())
                    {
                        if (actionName.ToLower() == method.Name.ToLower())
                        {
                            result = typeof(IndexController).GetMethod(method.Name).Invoke(index, null);
                            context.Response.Write(result);
                            break;
                        }
                    }
                    break;
                case "Orders":
                    OrdersController orders = new OrdersController(new OrdersService(new Repository()));
                    foreach (MethodInfo method in typeof(OrdersController).GetMethods())
                    {
                        if (actionName.ToLower() == method.Name.ToLower())
                        {
                            result = typeof(OrdersController).GetMethod(method.Name).Invoke(orders, null);
                            context.Response.Write(result);
                            break;
                        }
                    }
                    
                    

                    break;
                default:
                    break;
            }
            */
            //object result = new IndexController(new ProductsService(new Repository())).Index();
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}