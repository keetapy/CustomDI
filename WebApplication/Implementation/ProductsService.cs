using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Contracts;

namespace WebApplication.Implementation
{
    public class ProductsService : IProductsService
    {
        public ProductsService(IRepository repository)
        {
        }

        public object GetProducts()
        {
            return "products";
        }
    }
}