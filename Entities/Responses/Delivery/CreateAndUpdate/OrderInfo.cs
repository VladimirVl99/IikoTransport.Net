using IikoTransport.Net.Entities.Responses.Orders;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate
{
    /// <summary>
    /// Information about a created delivery order.
    /// </summary>
    [JsonObject]
    public class OrderInfo : OrderInfoShort
    {
        /// <summary>
        /// Order creation details.
        /// Field is filled up if "creationStatus"="Success".
        /// </summary>
        [JsonProperty(PropertyName = "order", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DeliveryOrder? Order { get; set; }
    }
}
