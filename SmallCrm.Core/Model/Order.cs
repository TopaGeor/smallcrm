using SmallCrm.Core.Model;
using System.Collections.Generic;

namespace SmallCrm.Core
{
    public class Order
    {
        /// <summary>
        /// The order id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The delivery address of the order
        /// </summary>
        public string DeliveryAddress { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderProduct> Products { get; set; }

        public Order()
        {
            {
                Products = new List<OrderProduct>();
            }
        }
    }
}
