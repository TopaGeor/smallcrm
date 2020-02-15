using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (options == null)
            {
                return false;
            }

            var check = GetProductById(options.Id);

            if (check != null)
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

            var product = new Product()
            {
                Id = options.Id,
                Name = options.Name,
                Price = options.Price,
                Category = options.Category
            };
            context_.Add(product);
            var success = false;
            
            try
            {
                success = context_.SaveChanges() > 0;
            }
            catch (Exception e)
            {

            }
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
            if (options == null)
            {
                return false;
            }

            var product = GetProductById(productId);

            if (product == null)
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
                if (options.Discount > 0M && options.Discount <= 100M)
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

            SearchProductOptions options = new SearchProductOptions()
            {
                Id = id
            };

            List<Product> product = SearchProduct(options);

            if (product.Count < 1)
            {
                return null;
            }
            else
            {
                return product[0];
            }
        }

        public List<Product> SearchProduct(SearchProductOptions options)
        {
            List<Product> returnList = new List<Product>();
            if (options == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(options.Id))
            {
                var temp = context_
                    .Set<Product>()
                    .SingleOrDefault(p => p.Id == options.Id);

                if (temp != default(Product))
                {
                    returnList.Add(temp);
                    return returnList;
                }
            }

            if (!string.IsNullOrWhiteSpace(options.Description))
            {
                returnList
                    .AddRange(
                    context_
                    .Set<Product>()
                    .Where(p => p.Description
                    .Contains(options.Description))
                    .ToList());
            }
            
            if (options.Discount > 0 && options.Discount < 100)
            {
                returnList.AddRange(context_
                    .Set<Product>()
                    .Where(p => p.Discount == options.Discount)
                    .ToList());
            }
            
            if (!string.IsNullOrWhiteSpace(options.Name))
            {
                returnList.AddRange(context_
                    .Set<Product>()
                    .Where(s => s.Name == options.Name)
                    .ToList());
            }
            
            if (options.Price > 0)
            {
                returnList.AddRange(context_
                    .Set<Product>()
                    .Where(p => p.Price == options.Price)
                    .ToList());
            }

            if (options.Category != ProductCategory.Invalid)
            {
                returnList.AddRange(context_
                    .Set<Product>()
                    .Where(p => p.Category == options.Category)
                    .ToList());
            }

            returnList = returnList.Distinct().ToList();

            return returnList;
        }

        public bool PopulateDb()
        {
            var rand = new Random();
            var p = 0M;
            var category = 0;
            var filename = "products.csv";
            foreach (var line in File.ReadAllLines(filename))
            {
                p = rand.Next(1, 100);
                p += (decimal)rand.NextDouble();
                p = decimal.Truncate(p * 100) / 100;

                category = rand.Next(1, 6);
                var splitedline = line.Split(';');
                Product newproduct = new Product()
                {
                    Id = splitedline[0],
                    Description = splitedline[1],
                    Price = p,
                    Category = (ProductCategory)category
                };

                context_.Add(newproduct);  
            }
            context_.SaveChanges();

            return true;
        }
    }
}
