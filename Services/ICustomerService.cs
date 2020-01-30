﻿using SmallCrm.Model;
using SmallCrm.Model.Options;
using System;
using System.Collections.Generic;

namespace SmallCrm.Services
{
    interface ICustomerService
    {
        /*
         * Create: a function that will add a new customer to a temporary, in-memory db (a list will do) and 
         * will ensure that for all new customers a VatNumber and e-mail address will be submitted. 
         * For every new customer submitted, a unique identifier is created. Old customers can be set to inactive, 
         * when it is well established by the sales-people, that they will no longer cooperate with us or when they fail to fulfill
         * their debts to our company.
         * Update: a function that will allow for a Customer's data to be updated selectively.
         * Search: a function that will return a list of active customers, filtered with a number of criteria such as DateCreated, VatNumber and email. 
         * More search criteria may be added as sales-people make heavier use of the system.
        */
        bool AddCustomer(AddCustomerOptions options);
        bool UpdateCustomer(UpdateCustomerOptions options);
        List<Customer> SearchCustomer(SearchCustomerOptions options);
    }
}