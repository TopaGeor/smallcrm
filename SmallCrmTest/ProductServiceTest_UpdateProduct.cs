using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System;
using Xunit;

namespace SmallCrmTest
{
    public partial class ProductServiceTest
    {
        [Fact]
        public void UpdateProduct_Success()
        {
            var product = new AddProductOptions()
            {
                Name = "product name",
                Price = 1230M,
                Category = ProductCategory.Cameras,
                Id = $"Test{CodeGenerator.CreateRandom()}"
            };

            Assert.True(psvc_.AddProduct(product));

            var updateproduct = new UpdateProductOptions()
            {
                Category = ProductCategory.Televisions,
                Description = $"lalilulelo{CodeGenerator.CreateRandom()}",
                Discount = 45M,
                Name = $"New Name {CodeGenerator.CreateRandom()}",
                Price = 45M
            };

            Assert.True(psvc_.UpdateProduct(product.Id, updateproduct));
        }
    }
}
