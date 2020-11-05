using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Contracts;

namespace WebApplication
{
    public class IndexController : BaseController
    {
        IProductsService productsService;
        public IndexController(IProductsService productsService)
        {
            this.productsService = productsService;

        }

        public object Index()
        {
            return productsService.GetProducts();
        }
    }
}