using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;
using System;
using Xunit;

namespace SmallCrmTest
{
    public partial class ProductServiceTest : IDisposable
    {
        private readonly SmallCrmDbContext context;
        private readonly ProductService psvc_;        

        public ProductServiceTest()
        {
            context = new SmallCrmDbContext();
            psvc_ = new ProductService(context);
        }

        [Fact]
        public void GetProductById_Success()
        {
            var product = new AddProductOptions()
            {
                Name = "product name",
                Price = 1230M,
                Category = ProductCategory.Cameras,
                Id = $"Test{CodeGenerator.CreateRandom()}"
            };

            Assert.True(psvc_.AddProduct(product));

            var retrivalProduct = psvc_.GetProductById(product.Id);

            Assert.NotNull(retrivalProduct);
            Assert.Equal(product.Price, retrivalProduct.Price);
        }

        [Fact]
        public void GetProductById_Failure_Null_ProductId()
        {
            var product = psvc_.GetProductById("  ");
            Assert.Null(product);
            
            product = psvc_.GetProductById(null);
            Assert.Null(product);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
