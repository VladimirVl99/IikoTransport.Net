using IikoTransport.Net.Entities.Common.Deliveries;
using IikoTransport.Net.Entities.Common.Orders;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Webhooks.Filters
{
    /// <summary>
    /// Filter for delivery orders.
    /// </summary>
    [JsonObject]
    public class DeliveryOrderFilter
    {
        /// <summary>
        /// Statuses of orders, when changing which need to send a notification.
        /// </summary>
        [JsonProperty(PropertyName = "orderStatuses", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public IEnumerable<DeliveryStatus>? OrderStatuses { get; set; }

        /// <summary>
        /// Statuses of order items, when changing which need to send a notification.
        /// </summary>
        [JsonProperty(PropertyName = "itemStatuses", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public IEnumerable<OrderItemStatus>? ItemStatuses { get; set; }

        /// <summary>
        /// Flag for errors.
        /// </summary>
        [JsonProperty(PropertyName = "errors", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Errors { get; set; }
    }
}
