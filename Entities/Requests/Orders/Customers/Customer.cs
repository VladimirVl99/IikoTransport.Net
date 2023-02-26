using IikoTransport.Net.Entities.Responses.Orders.Customers;
using Newtonsoft.Json;
using SourceCustomer = IikoTransport.Net.Entities.Responses.Delivery.Drafts.Customer;

namespace IikoTransport.Net.Entities.Requests.Orders.Customers
{
    /// <summary>
    /// For https://api-ru.iiko.services/api/1/order/add_customer request.
    /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1add_customer/post.
    /// </summary>
    [JsonObject]
    public class Customer : SourceCustomer
    {
        protected new CustomerType Type { get; set; }

        /// <summary>
        /// Customer phone.
        /// Required if "id" == null. Not required if "id" specified.
        /// </summary>
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Phone { get; set; }


        public Customer(Guid customerId, bool shouldReceiveOrderStatusNotifications = false)
        {
            Id = customerId;
            ShouldReceiveOrderStatusNotifications = shouldReceiveOrderStatusNotifications;
        }

        public Customer(string phone, string name)
        {
            Phone = phone;
            Name = name;
        }
    }
}
