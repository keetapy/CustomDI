using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Contracts;

namespace WebApplication
{
    public class OrdersController : BaseController
    {
        IOrdersService ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }
        public object GetData()
        {
            return ordersService.GetData();
        }
    }
}