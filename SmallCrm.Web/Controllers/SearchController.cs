using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Services;
using SmallCrm.Web.Models;

namespace SmallCrm.Web.Controllers
{
    public class SearchController : Controller
    {
        private SmallCrmDbContext context_ { get; set; }

        private ICustomerService customer_ { get; set; }

        private IProductService product_ { get; set; }

        public SearchController(SmallCrmDbContext context, ICustomerService customer, IProductService product)
        {
            context_ = context;
            customer_ = customer;
            product_ = product;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CustomerSearch()
        {
            return View(new SearchCustomerViewModel());
        }

        [HttpPost]
        public IActionResult CustomerSearch(SearchCustomerViewModel model)
        {
            var result = customer_.SearchCustomer(model?.SearchOptions);

            if (result == null)
            {
                model.ErrorText = "Oops Something went wrong";
                return View(model);
            }
            else
            {
                model.Results = result.ToList();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ProductSearch()
        {
            return View(new SearchProductViewModel());
        }

        [HttpPost]
        public IActionResult ProductSearch(SearchProductViewModel model)
        {
            model.Products = product_.SearchProduct(model?.Options);
            
            if (model.Products.Count < 1)
            {
                model.ErrorText = "Oops Something went wrong";
                return View(model);
            }
            return View(model);   
        }
    }
}