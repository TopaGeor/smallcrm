using System;
using System.Linq;
using System.Collections.Generic;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmallCrm.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly SmallCrmDbContext context_;
        private readonly ICustomerService customers_;

        public OrderService(ICustomerService customers, SmallCrmDbContext context)
        {
            context_ = context;
            customers_ = customers;
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

            Order order = GetOrderById(options.OrderId);

            if(order == null)
            {
                return false;
            }
            /*
            if (order.Status != OrderCategory.Pending)
            {
                return false;
            }
            
            if(options.Cancel == true)
            {
                order.Status = OrderCategory.Cancel;
                return true;
            }*/
            return true;
        }
        
        /// <summary>
        /// Return an Order with Id id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrderById(string id) 
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            try
            {
                return context_
                    .Set<Order>()
                    .SingleOrDefault(s => s.Id.Equals(id));     
            }
            catch
            {
                return null;
            }
        }

        public async Task<ApiResult<Order>> CreateOrder(int customerId, ICollection<string> productIds)
        {
            if( customerId <= 0)
            {
                return new ApiResult<Order>(
                    StatusCode.BadRequest,
                    $"Error with customer Id {customerId}");
            }

            if (productIds == null||
                productIds.Count == 0)
            {
                return new ApiResult<Order>(
                    StatusCode.BadRequest, 
                    "Error with the ids of products");
            }

            var customer = await customers_.SearchCustomer(
                new SearchCustomerOptions()
                {
                    Id = customerId
                })
                .Where(c => c.Active)
                .SingleOrDefaultAsync();

            if (customer == null ||
                productIds.Count == 0)
            {
                return new ApiResult<Order>(StatusCode.BadRequest, "No customer found");
            }

            var products = await context_
                .Set<Product>()
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            if (products.Count != productIds.Count)
            {
                return new ApiResult<Order>(StatusCode.BadRequest, 
                    "Error on something");
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

            return new ApiResult<Order> 
            {
                Data = order
            };
        }
    }
}
