using Serilog;
using System;

using SmallCrm.Model;
using SmallCrm.Model.Options;
using SmallCrm.Services;
namespace SmallCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new ProductService();
            product.AddProduct(new AddProductOptions()
            {
                Id = "1",
                Name = "Name1",
                Price = 100.00M,
                Category = ProductCategory.Cameras
            });

            product.AddProduct(new AddProductOptions()
            {
                Id = "2",
                Name = "Name2",
                Price = 101.00M,
                Category = ProductCategory.Computers
            });

            product.UpdateProduct("3", new UpdateProductOptions()
            {
                Name = "Name3"
            });
        }
    }
}

/*            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File($@"{System.IO.Directory.GetCurrentDirectory()}\logs\{DateTime.Now:yyyy-MM-dd}\log-.txt",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Error("this is an error");
            Console.ReadKey();
 */