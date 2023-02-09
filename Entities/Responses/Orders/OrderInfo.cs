using Newtonsoft.Json;

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
