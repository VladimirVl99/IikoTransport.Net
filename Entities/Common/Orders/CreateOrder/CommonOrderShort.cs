using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Orders.CreateOrder
{
    /// <summary>
    /// Common information about an order.
    /// </summary>
    [JsonObject]
    public class CommonOrderShort : GeneralOrderCreation
    {
        /// <summary>
        /// Order ID. Must be unique.
        /// If sent null, it generates automatically on iikoTransport side.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// [ 0 .. 50 ] characters.
        /// Order external number.
        /// Allowed from version 8.0.6.
        /// </summary>
        [JsonProperty(PropertyName = "externalNumber", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ExternalNumber { get; set; }

        /// <summary>
        /// [ 8 .. 40 ] characters.
        /// Telephone number.
        /// Must begin with symbol "+" and must be at least 8 digits.
        /// </summary>
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Phone { get; set; }

        /// <summary>
        /// Customer.
        /// </summary>
        [JsonProperty(PropertyName = "customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Customer? Customer { get; set; }

        /// <summary>
        /// Guest details. Not equal to the customer who makes an order.
        /// </summary>
        [JsonProperty(PropertyName = "guests", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GuestDetails? Guests { get; set; }
    }
}
