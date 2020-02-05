using SmallCrm.Core.Data;
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
            psvc_ = new ProductService(new SmallCrmDbContext());
        }

        [Fact]
        public void GetProductById_Success()
        {
            var product = psvc_.GetProductById("3445");
            Assert.NotNull(product);
            Assert.Equal(99.99M, product.Price);
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
