using SmallCrm.Model;
using SmallCrm.Model.Options;
using System.Collections.Generic;

namespace SmallCrm.Services
{
    interface ICustomerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        bool AddCustomer(AddCustomerOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        bool UpdateCustomer(UpdateCustomerOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        List<Customer> SearchCustomer(SearchCustomerOptions options);
    }
}
