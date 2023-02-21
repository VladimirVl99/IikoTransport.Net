using IikoTransport.Net.Entities.Common.Customers;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Draft customer.
    /// </summary>
    [JsonObject]
    public class Customer : CustomerShort
    {
        /// <summary>
        /// Existing customer ID in RMS.
        /// If null - the phone number is searched in database,
        /// otherwise the new customer is created in RMS.
        /// </summary>
        public override Guid? Id { get; set; }

        /// <summary>
        /// [ 0 .. 60 ] characters.
        /// Name of customer.
        /// Required for new customers (i.e. if "id" == null) Not required if "id" specified.
        /// </summary>
        public new string? Name { get; set; }

        /// <summary>
        /// [ 0 .. 60 ] characters.
        /// Last name.
        /// </summary>
        public override string? Surname { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Email { get; set; }

        /// <summary>
        /// Whether customer receives order status notification messages.
        /// </summary>
        [JsonProperty(PropertyName = "shouldReceiveOrderStatusNotifications", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ShouldReceiveOrderStatusNotifications { get; set; }
    }
}
