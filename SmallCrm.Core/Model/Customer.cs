using System;

namespace SmallCrm.Core.Model
{
    public class Customer
    {
        /// <summary>
        /// Custoemr id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Customer Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customer Last name
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Customer First name
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Customer VatNumber
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// Customer status
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// When the customer have being created
        /// </summary>
        public string CreationDate { get; set; }

        public DateTimeOffset Created { get; set; }

        public Customer()
        {
            Created = DateTimeOffset.Now;
        }
    }
}