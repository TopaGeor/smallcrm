using SmallCrm.Model;
using SmallCrm.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCrm.Services
{
    public class OrderService : IOrderService
    {
        private List<Order> OrderList = new List<Order>();

        public bool CreateOrder(CreateOrderOptions options)
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

            if (OrderList.Any(s => s.OrderId.Equals(options.OrderId)))
            {
                return false;
            }

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

            Order order = new Order
            {
                OrderId = options.OrderId,
                OwnerId = options.OwnerId,
                ProductList = options.ProductList,
                Executed = false
            };

            order.CalculateAmmount();
            OrderList.Add(order);
            return true;
        }

        public bool UpdateOrder(UpdateOrderOptions options)
        {
            return true;
        }

        public Order GetOrderById(string id) 
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

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
