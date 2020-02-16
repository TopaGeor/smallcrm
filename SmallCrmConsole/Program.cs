using SmallCrm.Core.Data;
using SmallCrm.Core.Services;
using ISO3166;
using System;
using SmallCrm.Core.Model;
using System.Collections.Generic;
using SmallCrm.Core;
using Autofac;
using System.Linq;

namespace SmallCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ps = new ProductService(new SmallCrmDbContext());
            var cs = new CustomerService(new SmallCrmDbContext());
            var options = new SmallCrm.Core.Model.Options.SearchCustomerOptions()
            { 
                Email = "customer@mail.com"
            };

            var t = cs.SearchCustomer(options).ToList();
            foreach(var x in typeof(Customer).GetProperties())
            {
                //Console.WriteLine(x.Name);
            }

        }
    }
}
