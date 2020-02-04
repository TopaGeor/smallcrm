using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// A list with customers
        /// </summary>
        private List<Customer> CustomerList = new List<Customer>();

        /// <summary>
        /// Creates a customer and adds him at the customer list
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool AddCustomer(AddCustomerOptions options)
        {
            if (options == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Email) ||
                string.IsNullOrWhiteSpace(options.VatNumber))
            {
                return false;
            }

            Customer customer = new Customer
            {
                VatNumber = options.VatNumber,
                Email = options.Email,
                Active = true,
                CreationDate = DateTime.UtcNow.ToString("yyyy MM dd")
            };

            CustomerList.Add(customer);
            return true;
        }

        /// <summary>
        /// Update a Customer according the options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool UpdateCustomer(UpdateCustomerOptions options)
        {
            var customer = GetCustomerById(options.Id);

            if (customer == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(options.Phone))
            {
                customer.Phone = options.Phone;
            }

            if (!string.IsNullOrWhiteSpace(options.Email))
            {
                customer.Email = options.Email;
            }

            if (!string.IsNullOrWhiteSpace(options.Lastname))
            {
                customer.Lastname = options.Lastname;
            }

            if (!string.IsNullOrWhiteSpace(options.Firstname))
            {
                customer.Firstname = options.Firstname;
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                customer.VatNumber = options.VatNumber;
            }

            if (options.ChangeActive)
            {
                customer.Active = !customer.Active;
            }

            return true;
        }

        /// <summary>
        /// Search for a customer according the options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public List<Customer> SearchCustomer(SearchCustomerOptions options)
        {
            List<Customer> ReturnList = CustomerList;
            
            if (!string.IsNullOrWhiteSpace(options.Email))
            {
                ReturnList = ReturnList.FindAll(
                    s => s.Email.Contains(options.Email));
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                ReturnList = ReturnList.FindAll(
                    s => s.VatNumber.Contains(options.VatNumber));
            }

            if (!string.IsNullOrWhiteSpace(options.FromDate) ||
                !string.IsNullOrWhiteSpace(options.ToDate))
            {
                ReturnList = ReturnList.FindAll(s =>
                s.CreationDate.CompareTo(options.FromDate) >= 0 &&
                s.CreationDate.CompareTo(options.ToDate) < 0
                );
            }

            ReturnList = ReturnList.FindAll(s => s.Active == true);

            return ReturnList; 
        }

        /// <summary>
        /// Return the Customer with id id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return CustomerList.SingleOrDefault(s => s.Id.Equals(id));
        }

        /// <summary>
        /// Return the Customer List
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomerList()
        {
            return CustomerList;
        }
    }
}
