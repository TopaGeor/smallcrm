using ISO3166;
namespace SmallCrm.Web.Models
{
    public class CreateCustomerViewModel
    {
        public Core.Model.Options.AddCustomerOptions CreateOptions { get; set; }
        public Country[] Countries = Country.List;

        public string ErrorText { get; set; }
    }
}
