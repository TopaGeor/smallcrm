using Microsoft.EntityFrameworkCore;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCrm.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductService products_;
        private readonly SmallCrmDbContext context_;
        private readonly ICustomerService customers_;

        public OrderService(
            ICustomerService customers, 
            SmallCrmDbContext context,
            IProductService products)
        {
            context_ = context;
            customers_ = customers;
            products_ = products;
        }

        /// <summary>
        /// Update an Order with options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool UpdateOrder(UpdateOrderOptions options)
        {
            if(options == null)
            {
                return false;
            }

            Task<Order> order = GetOrderById(options.OrderId);

            if(order == null)
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Return an Order with Id id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderById(string id) 
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            try
            {
                return await context_
                    .Set<Order>()
                    .SingleOrDefaultAsync(s => s.Id.Equals(id));     
            }
            catch
            {
                return null;
            }
        }

        public async Task<ApiResult<Order>> CreateOrder(
            int customerId, ICollection<string> productIds)
        {
            if( customerId <= 0)
            {
                return new ApiResult<Order>(
                    StatusCode.BadRequest,
                    $"Error with customer Id {customerId}");
            }

            var customer = await customers_.SearchCustomer(
                new SearchCustomerOptions()
                {
                    Id = customerId
                })
                .Where(c => c.Active)
                .SingleOrDefaultAsync();

            var products = new List<Product>();

            foreach (var p in productIds)
            {
                var presult = await products_
                    .GetProductByIdAsync(p);

                if (!presult.Success)
                {
                    var ret = presult.ConvertResult<Order>();

                    return new ApiResult<Order>(
                        presult.ErrorCode, presult.ErrorText);
                }

                products.Add(presult.Data);
            }

            if (customer == null ||
                productIds.Count == 0)
            {
                return new ApiResult<Order>(StatusCode.BadRequest, "No customer found");
            }

            var order = new Order()
            {
                Customer = customer
            };

            foreach(var p in products)
            {
                order.Products.Add(
                new OrderProduct()
                {
                    ProductId = p.Id
                }
                );
            }

            await context_.AddAsync(order);

            try
            {
                await context_.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new ApiResult<Order>(StatusCode.BadRequest, "Another error");
            }

            return ApiResult<Order>.CreateSucces(order);
        }
    }
}
