using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm.Core.Services
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// A list with orders
        /// </summary>
        private List<Order> OrderList = new List<Order>();

        /// <summary>
        /// Create an order and add it to the OrderList
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Order CreateOrder(CreateOrderOptions options)
        {
            if (options.Id <= 0)
            {
                return null;
            }

            if (options.ProductList.Count < 1)
            {
                return null;
            }

            /*
             * Check if id is unique
             */
            if (OrderList.Any(s => s.Id.Equals(options.Id)))
            {
                return null;
            }

            /*
             * Check if a customer is active and exist
             */
            try
            {
                if (!options.CustomerList.SingleOrDefault(s => s.Id.Equals(options.Id)).Active)
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

            /*
             * Check if all products exist
             */
            if (options.ProductList.Except(options.AvailableProductList).Any())
            {
                return null;
            }

            Order order = new Order
            {
                Id = options.Id,
                //CustomerId = options.OwnerId,
                //ProductList = options.ProductList,
                Status = OrderCategory.Pending
            };

            //order.CalculateAmmount();
            OrderList.Add(order);
            return order;
        }

        /// <summary>
        /// Update an Order with options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool UpdateOrder(UpdateOrderOptions options)
        {
            Order order = GetOrderById(options.OrderId);

            if(order == null)
            {
                return false;
            }

            if (order.Status != OrderCategory.Pending)
            {
                return false;
            }

            if(options.Cancel == true)
            {
                order.Status = OrderCategory.Cancel;
                return true;
            }
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
                return OrderList.SingleOrDefault(
                    s => s.Id.Equals(id));
            }
            catch
            {
                return null;
            }
        }
    }
}
