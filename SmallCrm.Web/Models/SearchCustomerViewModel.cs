using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCrm.Web.Models
{
    public class SearchCustomerViewModel
    {
        public Core.Model.Options.SearchCustomerOptions SearchOptions { get; set; }

        public List<Core.Model.Customer> Results;

        public SearchCustomerViewModel()
        {
            Results = new List<Core.Model.Customer>();
        }

        public string ErrorText { get; set; }
    }
}
