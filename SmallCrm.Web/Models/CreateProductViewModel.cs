using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCrm.Web.Models
{
    public class CreateProductViewModel
    {
        public Core.Model.Options.AddProductOptions CreateOptions { get; set; }
        public List<Object> Categories { get; set; }

        public CreateProductViewModel()
        {
            Categories = new List<object>();
            foreach (var x in Enum.GetValues(typeof(Core.Model.ProductCategory)))
            {
                Categories.Add(x);
            }
        }

        public string ErrorText { get; set; }
    }
}
