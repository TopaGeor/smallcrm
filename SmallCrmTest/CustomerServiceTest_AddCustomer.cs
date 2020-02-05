using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmallCrmTest
{
    public partial class CustomerServiceTest
    {
        [Fact]
        public void AddCustomer_Success()
        {
            var customer = new AddCustomerOptions()
            { 
                Email = "test@mail.com",
                FirstName = "Test first name",
                LastName = "Test last name",
                Phone = "6969696969",
                VatNumber = "TestVatNumber"
            };

            Assert.True(csvc_.AddCustomer(customer));
        }
    }
}
