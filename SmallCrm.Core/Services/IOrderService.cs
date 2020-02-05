using SmallCrm.Core.Model.Options;

namespace SmallCrm.Core.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// a function that will create and add a new order to the system, given at least a CustomerId, and a list of Products. 
        /// It should ensure that a product exists and that the customer maintains an active relationship with the company.It should
        /// return the newly created order to a sales-person, allowing for invoice printing or sent by email to the customer.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Order CreateOrder(CreateOrderOptions options);

        /// <summary>
        /// a function that will update a not-executed order, and will allow sales-people to cancel it, if the customer changed his mind 
        /// and wants to create a new one.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        bool UpdateOrder(UpdateOrderOptions options);

        /// <summary>
        /// a function that will return an order's details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order GetOrderById(string id);
    }
}
