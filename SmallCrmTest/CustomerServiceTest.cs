using Microsoft.EntityFrameworkCore;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;
using System;
using System.Linq;
using Xunit;

namespace SmallCrmTest
{
    public partial class CustomerServiceTest : IDisposable
    {
        private readonly ICustomerService csvc_;
        private readonly SmallCrmDbContext context;

        public CustomerServiceTest()
        {
            context = new SmallCrmDbContext();
            csvc_ = new CustomerService(context);
        }

        [Fact]
        public void CreateCustomer_Succsess()
        {
            var cOptions = new AddCustomerOptions()
            {
                Email = "customer@mail.com",
                FirstName = "Fname",
                LastName = "Lname",
                Phone = "343549342",
                VatNumber = $"{DateTime.UtcNow.Millisecond:D6}"
            };

            var customer = csvc_.AddCustomer(cOptions);

            Assert.NotNull(customer);

            var scustomer = csvc_.SearchCustomer(
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
        public void Customer_Order_Success()
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
            context.Add(p2);

            var customer = new Customer()
            { 
                VatNumber = "117003949",
                Email = "asdasd@as.gr"
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

            context.Add(customer);
            context.SaveChanges();
        }

        [Fact]
        public void Order_remove()
        {
            var order = context.Set<Order>().SingleOrDefault(o => o.Id == 2);

            context.Remove(order);
            context.SaveChanges();
        }

        [Fact]
        public void Customer_Order_Retrieve()
        {
            var customer = context
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
            context.Add(customer);
            context.SaveChanges();

            return customer.Id; 
        }

        [Fact]
        public void RetrieveContacts()
        {
            var customerId = AddCustomerContacts();
            var contacts = context
                .Set<Customer>()
                .Include(c => c.Contacts)
                .Where(c => c.Id == customerId)
                .Select(c => c.Contacts)
                .ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
