using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;
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

            Assert.True(psvc_.AddProduct(product));

            var p = psvc_.GetProductById(product.Id);
            Assert.NotNull(p);
            Assert.Equal(product.Name, p.Name);
            Assert.Equal(product.Price, p.Price);
            Assert.Equal(product.Category, p.Type);
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

            Assert.False(psvc_.AddProduct(product));
        }
    }
}
