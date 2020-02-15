using Autofac;
using Microsoft.AspNetCore.Mvc;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using System.Linq;

namespace SmallCrm.Web.Controllers
{
    public class ProductController : Controller
    {
        private IContainer Container { get; set; }
        private SmallCrmDbContext Context { get; set; }

        public ProductController()
        {
            Container = ServiceRegistrator.GetContainer();
            Context = Container.Resolve<SmallCrmDbContext>();
        }

        public IActionResult Index()
        {
            var productList = Context
                .Set<Product>()
                .Take(100)
                .ToList();

            var customerList = Context
                .Set<Customer>()
                .Take(100)
                .ToList();

            var model = new Models.CustomersProductsViewModel()
            {
                Customers = customerList,
                Products = productList
            };

            return View(model);
        }
    }
}