using SmallCrm.Core.Model;
using System.Collections.Generic;

namespace SmallCrm.Web.Models
{
    public class CustomersProductsViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
    }
}
