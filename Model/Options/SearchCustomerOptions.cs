namespace SmallCrm.Model.Options
{
    class SearchCustomerOptions
    {
        /// <summary>
        /// From what date we should search
        /// </summary>
        public string FromDate;

        /// <summary>
        /// To what date we should search
        /// </summary>
        public string ToDate;

        /// <summary>
        /// What Vat number we are looking for
        /// </summary>
        public string VatNumber;

        /// <summary>
        /// What email we are looking for
        /// </summary>
        public string Email;
    }
}
