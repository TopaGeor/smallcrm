using System;
using System.Linq;
using System.Collections.Generic;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;

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

        public Order CreateOrder(int customerId, ICollection<string> productIds)
        {
            if( customerId <= 0)
            {
                return null;
            }

            if (productIds == null||
                productIds.Count == 0)
            {
                return null;
            }

            var customer = customers_.SearchCustomer(
                new SearchCustomerOptions()
                {
                    Id = customerId
                })
                .Where(c => c.Active)
                .SingleOrDefault();

            if (customer == null ||
                productIds.Count == 0)
            {
                return null;
            }

            var products = context_
                .Set<Product>()
                .Where(p => productIds.Contains(p.Id))
                .ToList();

            if (products.Count != productIds.Count)
            {
                return null;
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

            context_.Add(order);

            try
            {
                context_.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return order;
        }
    }
}
