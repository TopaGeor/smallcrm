using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;
using System;
using System.Linq;

namespace SmallCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            var lal = new AddCustomerOptions();

            using (var context = new SmallCrmDbContext())
            {
                var productservice = new ProductService(context);
                productservice.AddProduct(
                    new AddProductOptions()
                    {
                        Id = "1",
                        Name = "a name",
                        Price = 30,
                        Category = ProductCategory.Computers
                    });
            }




            //context.Add(c);
            //context.SaveChanges();
            //context.Database.EnsureCreated();
            //Repository patern
            //Unit of work patern

            Console.WriteLine("Hello World!");
        }
    }
}
/*
 * var products = context.Set<Product>().Where(s => s.Price > 100).ToList();
            //Console.ReadKey();

            var p = new Product()
            {
                Id = "3451",
                Type = ProductCategory.Computers,
                Price = 99.99M,
                Discount = 0
            };

            context.Add(p);

            var c = new Customer()
            {
                Active = true,
                Created = DateTime.UtcNow,
                Email = "a@mail.com",
                Firstname = "F name",
                Lastname = "L name",
                Phone = "69696969",
                VatNumber = "69NB",
            };

                var c = context.Set<Customer>().Where(s => s.Id == 2).SingleOrDefault();

            if (c != null)
            {
                context.Remove(c);
                context.SaveChanges();
            }
                        Console.WriteLine(context.Database.CanConnect());
    */
