using SmallCrm.Model;
using SmallCrm.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm.Services
{
    class CustomerService : ICustomerService
    {
        private List<Customer> CustomerList = new List<Customer>();

        /// <summary>
        /// 
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
                string.IsNullOrWhiteSpace(options.VatNumber)||
                string.IsNullOrWhiteSpace(options.Id))
            {
                return false;
            }

            if (GetCustomerById(options.Id) != null)
            {
                return false;
            }

            Customer customer = new Customer
            {
                Id = options.Id,
                VatNumber = options.VatNumber,
                Email = options.Email,
                Active = true,
                CreationDateTime = DateTime.UtcNow.ToString("yyyy_mm_dd hh:mm:ss")
            };

            CustomerList.Add(customer);
            return true;
        }

        /// <summary>
        /// 
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

            if(!string.IsNullOrWhiteSpace(options.VatNumber))
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
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public List<Customer> SearchCustomer(SearchCustomerOptions options)
        {
            List<Customer> ReturnList = CustomerList;
            
            if (!string.IsNullOrWhiteSpace(options.Email))
            {
                ReturnList = ReturnList.FindAll(s => s.Email.Contains(options.Email));
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                ReturnList = ReturnList.FindAll(s => s.VatNumber.Contains(options.VatNumber));
            }

            if (!string.IsNullOrWhiteSpace(options.CreationDateTime))
            {
                ReturnList = ReturnList.FindAll(s => s.CreationDateTime.Contains(options.CreationDateTime));
            }

            ReturnList = ReturnList.FindAll(s => s.Active == true);

            return ReturnList; 
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomerList()
        {
            return CustomerList;
        }

    }
}
