using IikoTransport.Net.Entities.Common.Customers;
using IikoTransport.Net.Entities.Responses.Orders.Customers;
using Newtonsoft.Json;
using SourceCustomer = IikoTransport.Net.Entities.Responses.Delivery.Drafts.Customer;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers
{
    /// <summary>
    /// Draft customer.
    /// </summary>
    [JsonObject]
    public class Customer : SourceCustomer
    {
        /// <summary>
        /// For one-time customers.
        /// </summary>
        /// <param name="name">Name of customer.</param>
        public Customer(string name)
        {
            Name = name;
            Type = CustomerType.OneTime;
        }

        public Customer(CustomerType type, Guid? id = null, string? name = null, string? surname = null,
            string? comment = null, DateTime? birthday = null, string? email = null,
            bool? shouldReceiveOrderStatusNotifications = null, Gender? gender = null)
        {
            Type = type;
            Id = id;
            Name = name;
            Surname = surname;
            Comment = comment;
            Birthdate = birthday;
            Email = email;
            ShouldReceiveOrderStatusNotifications = shouldReceiveOrderStatusNotifications;
            Gender = gender;
        }
    }
}
