using Microsoft.EntityFrameworkCore;
using SmallCrm.Core.Data;
using SmallCrm.Core.Model;
using SmallCrm.Core.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ApiResult<Customer>> AddCustomer(AddCustomerOptions options)
        {
            if (options == null)
            {
                return new ApiResult<Customer>(StatusCode.NotFound, $"Null {options}");
            }

            if (string.IsNullOrWhiteSpace(options.Email) ||
                string.IsNullOrWhiteSpace(options.VatNumber)||
                string.IsNullOrWhiteSpace(options.Country))
            {
                return new ApiResult<Customer>(StatusCode.BadRequest, 
                    $"Null one of these {options.Email} {options.VatNumber} {options.Country}");
            }

            if (options.VatNumber.Length > 9)
            {
                return new ApiResult<Customer>(StatusCode.NotFound,
                    $"Vat number lenght longer than 9 {options.VatNumber}");
            }

            var exists = await SearchCustomer(
                new SearchCustomerOptions()
                {
                    VatNumber = options.VatNumber
                }).AnyAsync();

            if (exists)
            {
                return new ApiResult<Customer>(StatusCode.NotFound,
                    $"Vat number exists {options.VatNumber}");
            }

            Customer customer = new Customer
            {
                VatNumber = options.VatNumber,
                Email = options.Email,
                Firstname = options.FirstName,
                Lastname = options.LastName,
                Phone = options.Phone,
                Active = true,
                Created = DateTime.UtcNow,
                Country = options.Country
            };

            await context_.AddAsync(customer);
            try
            {    
                await context_.SaveChangesAsync();
            }
            catch
            {
                return new ApiResult<Customer>(StatusCode.NotFound,
                    "Failed on saving changes");
            }

            return ApiResult<Customer>.CreateSucces(customer);
        }

        /// <summary>
        /// Update a Customer according the options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCustomer(UpdateCustomerOptions options)
        {
            var customer = await GetCustomerById(options.Id);

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

            if (options.ChangeActive != null)
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
        public IQueryable<Customer> SearchCustomer(SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Email))
            {
                query = query.Where(c =>
                    c.Email == options.Email);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c =>
                    c.VatNumber == options.VatNumber);
            }

            if (options.Id != null)
            {
                query = query.Where(c => 
                    c.Id == options.Id);
            }

            return query.Take(500);
        }

        /// <summary>
        /// Return the Customer with id id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerById(int? id)
        {
            if(id == null)
            {
                return null;
            }

            var options = new SearchCustomerOptions()
            {
                Id = id
            };

            return await SearchCustomer(options)
                .SingleOrDefaultAsync();
        }
    }
}
