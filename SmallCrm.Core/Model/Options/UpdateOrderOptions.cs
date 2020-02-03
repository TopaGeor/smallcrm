using System.Collections.Generic;

namespace SmallCrm.Core.Model.Options
{
    public class UpdateOrderOptions
    {
        /// <summary>
        /// Update delivery address
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// What order we want to update
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// If we want to Cancel the order
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Update product list
        /// </summary>
        public List<Product> ProductList = new List<Product>();
    }
}
