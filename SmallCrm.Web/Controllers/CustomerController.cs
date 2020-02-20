using Autofac;
using Microsoft.AspNetCore.Mvc;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Services;
using SmallCrm.Core.Model.Options;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SmallCrm.Web.Extensions;

namespace SmallCrm.Web.Controllers
{
    public class CustomerController : Controller
    {
        private SmallCrmDbContext context_;

        private ICustomerService customers_;

        public CustomerController(SmallCrmDbContext context, ICustomerService customers)
        {
            context_ = context;
            customers_ = customers;
        }

        public IActionResult Index()
        {
            //var customerList = await context_
            //    .Set<Customer>()
            //    .Take(100)
            //    .ToListAsync();

            return View();
        }

        public async Task<IActionResult> List()
        {
            var customerList = await context_
                .Set<Customer>()
                .Select(c => new { c.Email, c.VatNumber })
                .Take(100)
                .ToListAsync();

            return Json(customerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Models.CreateCustomerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.CreateCustomerViewModel model)
        {
            var result = await customers_.AddCustomer(model?.CreateOptions);
            
            if(result == null)
            {
                model.ErrorText = "Oops Something went wrong";
                return View(model);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromPostman(
            [FromBody] AddCustomerOptions options)
        {
            var result = await customers_.AddCustomer(options);

            return result.AsStatusResult();
        }
    }
}