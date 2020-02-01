using SmallCrm.Model;
using System.Collections.Generic;

namespace SmallCrm
{
    public class Order
    {
        /// <summary>
        /// The id of the customer how made the order
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// The order id
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// The delivery address of the order
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// Send by email the receipt
        /// </summary>
        public bool SendByEmail { get; set; }

        /// <summary>
        /// The total cost of the order
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// A list of the products of the order
        /// </summary>
        public List<Product> ProductList = new List<Product>();

        /// <summary>
        /// The status of the order
        /// </summary>
        public OrderCategory Status { get; set; }

        /// <summary>
        /// Calculate the cost of the order
        /// </summary>
        public void CalculateAmmount()
        {
            decimal? d = 0;
            foreach (Product p in ProductList)
            {
                d = d + p.Price;
            }
            TotalAmount = d;
        }
    }
}
