using SmallCrm.Model;
using System.Collections.Generic;

namespace SmallCrm
{
    public class Order
    {
        /// <summary>
        /// 
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SendByEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product> ProductList = new List<Product>();

        /// <summary>
        /// 
        /// </summary>
        public OrderCategory Status { get; set; }

        /// <summary>
        /// 
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
