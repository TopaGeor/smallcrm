using Autofac;
using Microsoft.EntityFrameworkCore;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SmallCrmTest
{
    public partial class CustomerServiceTest : IClassFixture<SmallCrmFixture>
    {
        private SmallCrmDbContext context_;
        private ICustomerService customers_;
        private IOrderService orders_;
        private IProductService products_;

        public CustomerServiceTest(SmallCrmFixture fixture)
        {
            context_ = fixture.DbContext;
            customers_ = fixture.Container.Resolve<ICustomerService>();
            products_ = fixture.Container.Resolve<IProductService>();
            orders_ = fixture.Container.Resolve<IOrderService>();
        }

        [Fact]
        public async Task CreateCustomer_Succsess()
        {
            var cOptions = new AddCustomerOptions()
            {
                Email = "customer@mail.com",
                FirstName = "Fname",
                LastName = "Lname",
                Phone = "343549342",
                VatNumber = $"{DateTime.UtcNow.Millisecond:D6}",
                Country = "BT"
            };

            var customer = await customers_.AddCustomer(cOptions);

            Assert.NotNull(customer);

            var scustomer = customers_.SearchCustomer(
                new SearchCustomerOptions()
                {
                    VatNumber = cOptions.VatNumber
                }
                ).SingleOrDefault();

            Assert.NotNull(scustomer);
            Assert.Equal(cOptions.Email, scustomer.Email);
            Assert.Equal(cOptions.FirstName, scustomer.Firstname);
            Assert.Equal(cOptions.LastName, scustomer.Lastname);
            Assert.True(scustomer.Active);
        }

        [Fact]
        public Order Customer_Order_Success()
        {
            var p = new Product()
            {
                Id = $"213{DateTime.Now.Millisecond}",
                Category = ProductCategory.Cameras,
                Name = "lalilulelo",
                Price = 123.44M
            };

            var p2 = new Product()
            {
                Id = $"214{DateTime.Now.Millisecond}",
                Category = ProductCategory.Computers,
                Name = "lalilulelo1",
                Price = 133.44M
            };
            context_.Add(p2);

            var customer = new Customer()
            { 
                VatNumber = $"{CodeGenerator.CreateRandom()}",
                Email = $"{CodeGenerator.CreateRandom()}"
            };

            var order = new Order()
            {
                DeliveryAddress = "Kleeman"
            };

            var op = new OrderProduct()
            {
                ProductId = p2.Id
            };

            order.Products.Add(op);
            customer.Orders.Add(order);

            context_.Add(customer);
            context_.SaveChanges();
            return order;
        }

        [Fact]
        public void Order_remove()
        {
            var order = Customer_Order_Success();
            //var order = context_.Set<Order>().SingleOrDefault(o => o.Id == 2);

            context_.Remove(order);
            context_.SaveChanges();
        }

        [Fact]
        public void Customer_Order_Retrieve()
        {
            var customer = context_
                .Set<Customer>()
                .Include(c => c.Orders)
                .ToList();

            Assert.NotNull(customer);
        }
        
        [Fact]
        public int AddCustomerContacts()
        {
            var customer = new Customer()
            {
                Firstname = $"name {CodeGenerator.CreateRandom()}",
                Lastname = "lname",
                Email = $"{CodeGenerator.CreateRandom()}@test.com",
                VatNumber = $"{CodeGenerator.CreateRandom()}"
            };
            
            var contacts = new ContactPerson()
            { 
                Email = "pn.com"
            };
            
            customer.Contacts.Add(contacts);
            context_.Add(customer);
            context_.SaveChanges();

            return customer.Id; 
        }

        [Fact]
        public void RetrieveContacts()
        {
            var customerId = AddCustomerContacts();
            var contacts = context_
                .Set<Customer>()
                .Include(c => c.Contacts)
                .Where(c => c.Id == customerId)
                .Select(c => c.Contacts)
                .ToList();
        }

        [Fact]
        public async Task CreateCustomer_Fail_VatNumber()
        {
            var options = new AddCustomerOptions()
            { 
                Email ="test@mail.com",
                FirstName = "Fname",
                LastName = "Lname",
                Phone = "2131231"
            };

            var result = await customers_.AddCustomer(options);

            Assert.Equal(StatusCode.BadRequest, result.ErrorCode);
        }
    }
}
