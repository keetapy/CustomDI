using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Contracts;

namespace WebApplication.Implementation
{
    public class OrdersService : IOrdersService
    {
        public OrdersService(IRepository repository)
        {
        }

        public object GetData()
        {
            return "data";
        }
    }
}