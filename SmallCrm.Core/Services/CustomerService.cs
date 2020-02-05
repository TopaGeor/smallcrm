using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SmallCrmDbContext context_;

        public CustomerService(SmallCrmDbContext context)
        {
            context_ = context ??
                throw new ArgumentNullException(nameof(context));
        }

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
                Created = DateTime.UtcNow
            };

            try
            {
                context_.Add(customer);
                context_.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
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
            if (options == null)
            {
                return null;
            }

            List<Customer> returnList = new List<Customer>();

            if (options.Id > 0)
            {
                var temp = context_
                    .Set<Customer>()
                    .FirstOrDefault(c => c.Id == options.Id);

                if (temp != default(Customer))
                {
                    returnList.Add(temp);
                    return returnList;
                }
            }

            if (!string.IsNullOrWhiteSpace(options.Email))
            {
                returnList
                    .AddRange
                    (context_
                    .Set<Customer>()
                    .Where(c => c.Email
                    .Contains(options.Email))
                    .ToList());
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                returnList
                    .AddRange
                    (context_
                    .Set<Customer>()
                    .Where(c => c.VatNumber
                    .Contains(options.VatNumber))
                    .ToList());
            }

            if (options.FromDate != default(DateTimeOffset) &&
                options.ToDate != default(DateTimeOffset))
            {
                returnList
                    .AddRange
                    (context_
                    .Set<Customer>()
                    .Where(c =>
                    c.Created.CompareTo(options.FromDate) >= 0
                    && c.Created.CompareTo(options.ToDate) >= 0)
                    .ToList()); 
            }

            returnList = returnList.Distinct().ToList();
            returnList = returnList.FindAll(s => s.Active == true);

            return returnList; 
        }

        /// <summary>
        /// Return the Customer with id id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int id)
        {
            if(id < 1)
            {
                return null;
            }
            var options = new SearchCustomerOptions()
            {
                Id = id
            };

            List<Customer> localList = SearchCustomer(options);
            if(localList.Count < 1)
            {
                return null;
            }
            else
            {
                return localList[0];
            }
        }
    }
}
