namespace SmallCrm.Core.Model.Options
{
    public class UpdateCustomerOptions
    {
        /// <summary>
        /// What customer we want to update
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Update the phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Update the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Update Last name
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Update first name
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Update vat number
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// If we want to change the customer status
        /// </summary>
        public bool ChangeActive { get; set; }/////edw exeis aporia
    }
}
