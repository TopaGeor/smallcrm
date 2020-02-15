using Autofac;
using Microsoft.AspNetCore.Mvc;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Services;
using SmallCrm.Core.Model.Options;
using System.Linq;

namespace SmallCrm.Web.Controllers
{
    public class CustomerController : Controller
    {
        private IContainer Container { get; set; }
        private SmallCrmDbContext Context { get; set; }

        private ICustomerService customers_;

        public CustomerController()
        {
            Container = ServiceRegistrator.GetContainer();
            Context = Container.Resolve<SmallCrmDbContext>();
            customers_ = Container.Resolve<ICustomerService>();
        }

        public IActionResult Index()
        {
            var customerList = Context
                .Set<Customer>()
                .Take(100)
                .ToList();

            return View(customerList);
        }

        public IActionResult List()
        {
            var customerList = Context
                .Set<Customer>()
                .Select(c => new { c.Email, c.VatNumber })
                .Take(100)
                .ToList();

            return Json(customerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.CreateCustomerViewModel model)
        {
            var result = customers_.AddCustomer(model?.CreateOptions);

            if(result == null)
            {
                model.ErrorText = "Oops Something went wrong";
                return View(model);
            }

            return Ok();
        }
    }
}