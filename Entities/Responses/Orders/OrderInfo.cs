using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.Orders.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Information about a created order.
    /// </summary>
    [JsonObject]
    public class OrderInfo : OrderInfoShort
    {
        /// <summary>
        /// Order creation details.
        /// Field is filled up if "creationStatus"="Success".
        /// </summary>
        [JsonProperty(PropertyName = "order", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Order? Order { get; set; }
    }
}
