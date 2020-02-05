using SmallCrm.Core.Model.Options;
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
