using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Product> ProductList = new List<Product>();

        /// <summary>
        /// 
        /// </summary>
        public List<Customer> CustomerList = new List<Customer>();
    }
}
