using SmallCrm.Core.Data;
using SmallCrm.Core.Services;
using ISO3166;
using System;

namespace SmallCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ps = new ProductService(new SmallCrmDbContext());

            var country = Country.List;
            foreach(var c in country)
            {
                Console.WriteLine(c.Name);
            }
            //ps.PopulateDb();
        }
    }
}
