using Autofac;
using SmallCrm.Core;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using SmallCrm.Core.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SmallCrmTest
{
    public partial class ProductServiceTest : IClassFixture<SmallCrmFixture>
    {
        private SmallCrmDbContext context_;
        private ICustomerService customers_;
        private IOrderService orders_;
        private IProductService products_;

        public ProductServiceTest(SmallCrmFixture fixture)
        {
            context_ = fixture.DbContext;
            customers_ = fixture.Container.Resolve<ICustomerService>();
            products_ = fixture.Container.Resolve<IProductService>();
            orders_ = fixture.Container.Resolve<IOrderService>();
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

            Assert.True(products_.AddProduct(product));

            var retrivalProduct = products_.GetProductById(product.Id);

            Assert.NotNull(retrivalProduct);
            Assert.Equal(product.Price, retrivalProduct.Price);
        }

        [Fact]
        public void GetProductById_Failure_Null_ProductId()
        {
            var product = products_.GetProductById("  ");
            Assert.Null(product);
            
            product = products_.GetProductById(null);
            Assert.Null(product);
        }
    }
}
