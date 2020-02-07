using System.Collections.Generic;

namespace SmallCrm.Core.Model.Options
{
    public class AddOrderOptions
    {
        /// <summary>
        /// The id of the order
        /// </summary>
        public int Id;

        /// <summary>
        /// A list with all availabe products
        /// </summary>
        public List<Product> AvailableProductList = new List<Product>();

        /// <summary>
        /// A list products inside the order
        /// </summary>
        public List<Product> ProductList = new List<Product>();

        /// <summary>
        /// A list with all customers
        /// </summary>
        public List<Customer> CustomerList = new List<Customer>();
    }
}
