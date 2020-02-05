using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System.Collections.Generic;

namespace SmallCrm.Core.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        bool AddProduct(AddProductOptions options);

        /// <summary>
        /// Update the product with id productId according to options
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool UpdateProduct(string productId, UpdateProductOptions options);

        /// <summary>
        /// Return the product with Id id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProductById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool PopulateDb();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        List<Product> SearchProduct(SearchProductOptions options);
    }
}
