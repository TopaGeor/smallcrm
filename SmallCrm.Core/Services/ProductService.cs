using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm.Core.Services
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Variable that conect as all, with the database
        /// </summary>
        private readonly SmallCrmDbContext context_;

        public ProductService(SmallCrmDbContext context)
        {
            context_ = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Creates a product according to options and adds it to the ProductList
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

            var success = false;

            context_.Add(product);
            try
            {
                success = context_.SaveChanges() > 0;
            }
            catch (Exception e)
            {

            }
            //ProductList.Add(product);
            return success;
        }
        
        /// <summary>
        /// Find the product with id productId and updates it with the options
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
        /// Return the product that has an id equals to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return context_.
                Set<Product>().
                SingleOrDefault(s => s.Id == id);
        }

        public Product SearchProduct(SearchProductOptions options)
        {
            if (options == null)
            {
                return null;
            }



            return null;
        }
    }
}
