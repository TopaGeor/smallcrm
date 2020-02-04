namespace SmallCrm.Core.Model.Options
{
    public class AddCustomerOptions
    {
        /// <summary>
        /// The Vat number of the Customer
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// The email of the Customer
        /// </summary>
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
    }
}
