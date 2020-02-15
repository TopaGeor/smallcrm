using Autofac;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SmallCrmTest 
{
    public class OrderServiceTest : IClassFixture<SmallCrmFixture>
    {
        private SmallCrmDbContext context_;
        private ICustomerService customers_;
        private IOrderService orders_;
        private IProductService products_;

        public OrderServiceTest(SmallCrmFixture fixture)
        {
            context_ = fixture.DbContext;
            customers_ = fixture.Container.Resolve<ICustomerService>();
            products_ = fixture.Container.Resolve<IProductService>();
            orders_ = fixture.Container.Resolve<IOrderService>();
        }

        [Fact]
        public void CreateOrder_Success()
        {
            var p0 = new AddProductOptions()
            {
                Name = "p0name",
                Price = 1230M,
                Category = ProductCategory.Cameras,
                Id = $"Test{CodeGenerator.CreateRandom()}"
            };

            var p1 = new AddProductOptions()
            {
                Name = "p1name",
                Price = 1230M,
                Category = ProductCategory.Cameras,
                Id = $"Test{CodeGenerator.CreateRandom()}"
            };
            Assert.True(products_.AddProduct(p0));
            Assert.True(products_.AddProduct(p1));

            var customer = customers_
                .AddCustomer(new AddCustomerOptions()
                {
                    Email = $"{CodeGenerator.CreateRandom()}@test.com",
                    VatNumber = $"{CodeGenerator.CreateRandom()}",
                    Country = "BT"
                }
                );
            Assert.NotNull(customer);

            var productIds = new List<string> { p0.Id, p1.Id };

            var order = orders_.CreateOrder(
                customer.Id, productIds);
            
            Assert.NotNull(order);

            var dbOrder = context_.Set<Order>().Find(order.Id);
            Assert.NotNull(dbOrder);

            Assert.True(customer.Id == dbOrder.Customer.Id);

            foreach(var p in productIds)
            {
                Assert.Contains(dbOrder.Products
                    .Select(prod => prod.ProductId), prod => prod.Equals(p));
            }
        }
    }
}
