using SmallCrm.Model;
using SmallCrm.Model.Options;
using System;
using System.Collections.Generic;

namespace SmallCrm.Services
{
    interface ICustomerService
    {
        bool AddCustomer(AddCustomerOptions options);
        bool UpdateCustomer(UpdateCustomerOptions options);
        List<Customer> SearchCustomer(SearchCustomerOptions options);
    }
}
