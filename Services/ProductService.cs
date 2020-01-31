using SmallCrm.Model;
using SmallCrm.Model.Options;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm.Services
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        private List<Product> ProductList = new List<Product>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool AddProduct(AddProductOptions options)
        {
            var check = GetProductById(options.Id);

            if (check != null)
            {
                return false;
            }

            if (options == null)
            {
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(options.Name))
            {
                return false;
            }
            if (options.Price <= 0)
            {
                return false;
            }
            if (options.Category == Model.ProductCategory.Invalid)
            {
                return false;
            }

            var product = new Product
            {
            Id = options.Id,
            Name = options.Name,
            Price = options.Price,
            Type = options.Category
            };

            ProductList.Add(product);
            return true;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool UpdateProduct(string productId, UpdateProductOptions options)
        {
            var product = GetProductById(productId);
            if (product == null)
            {
                return false;
            }

            if (options == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(options.Description))
            {
                product.Description = options.Description;
            }

            if (!string.IsNullOrWhiteSpace(options.Name))
            {
                product.Name = options.Name;
            }

            if (options.Price != null)
            {
                if (options.Price <= 0)
                {
                    return false;
                }
                else
                {
                    product.Price = options.Price;
                }
            }

            if (options.Discount != null)
            {
                if (options.Discount < 0 && options.Discount >= 100)
                {
                   product.Discount = options.Discount;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return ProductList.SingleOrDefault(s => s.Id.Equals(id));
        }
    }
}
