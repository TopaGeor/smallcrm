using SmallCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product> ProductList = new List<Product>();

        /// <summary>
        /// 
        /// </summary>
        public bool Executed { get; set; }

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
