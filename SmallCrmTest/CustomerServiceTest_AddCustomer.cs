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
                Email = $"{CodeGenerator.CreateRandom()}@test.com",
                FirstName = "Test first name",
                LastName = "Test last name",
                Phone = "6969696969",
                VatNumber = $"{CodeGenerator.CreateRandom()}"
            };

            Assert.NotNull(customers_.AddCustomer(customer));
        }
    }
}
