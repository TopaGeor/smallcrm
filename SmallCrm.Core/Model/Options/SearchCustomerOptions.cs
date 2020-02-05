using System;

namespace SmallCrm.Core.Model.Options
{
    public class SearchCustomerOptions
    {
        /// <summary>
        /// From what date we should search
        /// </summary>
        public DateTimeOffset FromDate;

        /// <summary>
        /// To what date we should search
        /// </summary>
        public DateTimeOffset ToDate;

        /// <summary>
        /// What Vat number we are looking for
        /// </summary>
        public string VatNumber;

        /// <summary>
        /// What email we are looking for
        /// </summary>
        public string Email;
        
        /// <summary>
        /// 
        /// </summary>
        public int Id;
    }
}
