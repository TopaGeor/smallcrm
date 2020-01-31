using SmallCrm.Model;
using SmallCrm.Model.Options;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm.Services
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// 
        /// </summary>
        private List<Order> OrderList = new List<Order>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Order CreateOrder(CreateOrderOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.OrderId)||
                string.IsNullOrWhiteSpace(options.OwnerId))
            {
                return false;
            }

            if (options.ProductList.Count < 1)
            {
                return false;
            }

            /*
             * Check if id is unique
             */
            if (OrderList.Any(s => s.OrderId.Equals(options.OrderId)))
            {
                return false;
            }

            /*
             * Check if a customer is active and exist
             */
            try
            {
                if (!options.CustomerList.SingleOrDefault(s => s.Id.Equals(options.OrderId)).Active)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            /*
             * Check if all products exist
             */
            if (options.ProductList.Except(options.AvailableProductList).Any())
            {
                return false;
            }

            Order order = new Order
            {
                OrderId = options.OrderId,
                OwnerId = options.OwnerId,
                ProductList = options.ProductList,
                Status = OrderCategory.Pending
            };

            order.CalculateAmmount();
            OrderList.Add(order);
            return order;
        }

        /// <summary>
        /// 
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
        /// 
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
                return OrderList.SingleOrDefault(s => s.OrderId.Equals(id));
            }
            catch
            {
                return null;
            }
        }
    }
}
