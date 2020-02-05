using SmallCrm.Core.Data;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;
using System;
using Xunit;

namespace SmallCrmTest
{
    public partial class ProductServiceTest
    {
        [Fact]
        public void UpdateProduct_Success()
        {
            var oldproduct = psvc_.GetProductById("Test_435");

            var updateproduct = new UpdateProductOptions()
            {
                Category = SmallCrm.Core.Model.ProductCategory.Televisions,
                Description = $"lalilulelo{DateTime.UtcNow.Millisecond}",
                Discount = 45M,
                Name = $"New Name {DateTime.UtcNow.Millisecond}",
                Price = 45M
            };

            Assert.True(psvc_.UpdateProduct(oldproduct.Id, updateproduct));
            /*
            var newproduct = psvc_.GetProductById(oldproduct.Id);

            Assert.Equal(updateproduct.Category, newproduct.Category);
            Assert.Equal(oldproduct.Category, newproduct.Category);
            Assert.Equal(oldproduct.Price, newproduct.Price);
            Assert.Equal(oldproduct.Name, newproduct.Name);
            */
            //Assert.Equal(old);
            //Assert.Equal

        }
    }
}
