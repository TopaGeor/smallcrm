using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System;
using Xunit;

namespace SmallCrmTest
{
    public partial class ProductServiceTest
    {
        [Fact]
        public void AddProduct_Success()
        {
            var product = new AddProductOptions()
            {
                Id = $"Test_{DateTime.UtcNow.Millisecond}",
                Name = "Camer Test",
                Price = 69M,
                Category = ProductCategory.Cameras
            };

            Assert.True(products_.AddProduct(product));

            var p = products_.GetProductById(product.Id);
            Assert.NotNull(p);
            Assert.Equal(product.Name, p.Name);
            Assert.Equal(product.Price, p.Price);
            Assert.Equal(product.Category, p.Category);
        }

        [Fact]
        public void AddProduct_Failure()
        {
            var product = new AddProductOptions()
            { 
                Id = "This a test id",
                Name = "Test name",
                Price = 40M,
            };

            Assert.False(products_.AddProduct(product));
        }
    }
}
