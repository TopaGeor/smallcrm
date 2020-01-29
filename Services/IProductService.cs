using System;

using SmallCrm.Model;
using SmallCrm.Model.Options;
namespace SmallCrm.Services
{
    interface IProductService
    {
        bool AddProduct(AddProductOptions options);

        bool UpdateProduct(string productId, UpdateProductOptions options);

        Product GetProductById(string id);
    }
}