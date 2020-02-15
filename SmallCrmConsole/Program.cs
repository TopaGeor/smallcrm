using SmallCrm.Core.Data;
using SmallCrm.Core.Services;
using ISO3166;
using System;
using SmallCrm.Core.Model;
using System.Collections.Generic;

namespace SmallCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ps = new ProductService(new SmallCrmDbContext());
            int[] a = new int[] { 1, 2, 3 };
            //List<Core.Model.ProductCategory> Categories { get; set; }
            List<Object> test = new List<Object>();
            foreach (var i in Enum.GetValues(typeof(ProductCategory)))
            {
                Console.WriteLine(i);
                test.Add(i);
            }
            //object[] test = new object[1];
            //List<Object> test = new List<Object>();
            //Console.WriteLine(x);
            //ps.PopulateDb();
        }
    }
}
