using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCrm.Web.Models
{
    public class SearchProductViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Core.Model.Options.SearchProductOptions Options { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Core.Model.Product> Products { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Object> Categories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorText { get; set; }

        public SearchProductViewModel()
        {
            Products = new List<Core.Model.Product>();
            Categories = new List<object>();
            
            foreach (var x in Enum.GetValues(typeof(Core.Model.ProductCategory)))
            {
                Categories.Add(x);
            }
        }
    }
}
