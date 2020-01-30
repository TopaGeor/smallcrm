using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Product> ProductList = new List<Product>();


    }
}
