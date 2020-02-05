using System;
using System.Collections.Generic;

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
        /// 
        /// </summary>
        public ICollection<ContactPerson> Contacts { get; set; }

        /// <summary>
        /// When the customer have being created
        /// </summary>
        public string CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Order> Orders {get; set;}

        /// <summary>
        /// 
        /// </summary>
        public Customer()
        {
            Created = DateTimeOffset.Now;
            Orders = new List<Order>();
            Contacts = new List<ContactPerson>();
        }

    }
}