using Autofac;
using Microsoft.AspNetCore.Mvc;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Services;
using SmallCrm.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm.Web.Controllers
{
    public class ProductController : Controller
    {
        private SmallCrmDbContext context_ { get; set; }
        private IProductService product_ { get; set; }

        public ProductController(SmallCrmDbContext context, IProductService product)
        {
            context_ = context;
            product_ = product;
        }

        public IActionResult Index()
        {
            var productList = context_
                .Set<Product>()
                .Take(100)
                .ToList();

            var customerList = context_
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

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateProductViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            var result = product_.AddProduct(model?.CreateOptions);

            if (!result)
            {
                model.ErrorText = "Oops Something went wrong";
                return View(model);
            }
            return Ok();
        }
    }
}
