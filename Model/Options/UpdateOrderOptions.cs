using System.Collections.Generic;

namespace SmallCrm.Model.Options
{
    public class UpdateOrderOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product> ProductList = new List<Product>();
    }
}
