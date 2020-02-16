using System;

namespace SmallCrm.Core.Model.Options
{
    public class SearchCustomerOptions
    {
        /// <summary>
        /// From what date we should search
        /// </summary>
        public DateTimeOffset FromDate { get; set; }

        /// <summary>
        /// To what date we should search
        /// </summary>
        public DateTimeOffset ToDate { get; set; }

        /// <summary>
        /// What Vat number we are looking for
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// What email we are looking for
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }
    }
}
