﻿using SmallCrm.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCrm.Services
{
    interface IOrderService
    {
        /*
         * Create: a function that will create and add a new order to the system, given at least a CustomerId, and a list of Products. 
         * It should ensure that a product exists and that the customer maintains an active relationship with the company. It should 
         * return the newly created order to a sales-person, allowing for invoice printing or sent by email to the customer.
         * Update: a function that will update a not-executed order, and will allow sales-people to cancel it, if the customer changed his mind 
         * and wants to create a new one.
         * GetOrderById: a function that will return an order's details.
        */
        bool CreateOrder(CreateOrderOptions options);

        bool UpdateOrder(UpdateOrderOptions options);

        Order GetOrderById(string id);
    }
}