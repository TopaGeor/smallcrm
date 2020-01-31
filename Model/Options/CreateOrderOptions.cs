using System.Collections.Generic;

namespace SmallCrm.Model.Options
{
    public class CreateOrderOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string OwnerId;

        /// <summary>
        /// 
        /// </summary>
        public string OrderId;

        /// <summary>
        /// 
        /// </summary>
        public List<Product> AvailableProductList = new List<Product>();

        /// <summary>
        /// 
        /// </summary>
        public List<Product> ProductList = new List<Product>();

        /// <summary>
        /// 
        /// </summary>
        public List<Customer> CustomerList = new List<Customer>();
    }
}
