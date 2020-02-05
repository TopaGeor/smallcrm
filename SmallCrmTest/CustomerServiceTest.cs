using Microsoft.EntityFrameworkCore;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
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
            csvc_ = new CustomerService(new SmallCrmDbContext());
        }

        [Fact]
        public void Customer_Order_Success()
        {
            var customer = new Customer()
            { 
                VatNumber = "117003949",
                Email = "asdasd.gr"
            };

            customer.Orders.Add(
                new SmallCrm.Core.Order()
                {
                    DeliveryAddress = "Kleeman"
                });

            context.Add(customer);
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
                Firstname = "name",
                Lastname = "lname",
                Email = "e@mail.com"
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

        /*
        [Fact]
        public void AddCustomer_Success()
        {
            var result = csvc_.AddCustomer(
                new AddCustomerOptions()
                {
                    Email = "asdasd.gr",
                    VatNumber = "117003949"
                });
        }*/
    }
}
