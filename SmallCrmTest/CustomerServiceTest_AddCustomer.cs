using SmallCrm.Core.Model.Options;
using System.Threading.Tasks;
using Xunit;

namespace SmallCrmTest
{
    public partial class CustomerServiceTest
    {
        [Fact]
        public async Task AddCustomer_Success()
        {
            var customer = new AddCustomerOptions()
            { 
                Email = $"{CodeGenerator.CreateRandom()}@test.com",
                FirstName = "Test first name",
                LastName = "Test last name",
                Phone = "6969696969",
                VatNumber = $"{CodeGenerator.CreateRandom()}",
                Country = "BT"
            };

            Assert.NotNull(await customers_.AddCustomer(customer));
        }
    }
}
