using IikoTransport.Net.Entities.Common.Orders.CreateOrder;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders.CreateOrder
{
    /// <summary>
    /// Common information about a table order.
    /// </summary>
    [JsonObject]
    public class OrderShort : CommonOrderShort
    {
        /// <summary>
        /// Table IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/reserve/available_restaurant_sections operation.
        /// </summary>
        [JsonProperty(PropertyName = "tableIds", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid>? TableIds { get; set; }

        /// <summary>
        /// Tab name (only for fastfood terminals group in tab mode).
        /// Allowed from version 7.6.1.
        /// </summary>
        [JsonProperty(PropertyName = "tabName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? TabName { get; set; }

        /// <summary>
        /// Order type ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/deliveries/order_types operation.
        /// </summary>
        [JsonProperty(PropertyName = "orderTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? OrderTypeId { get; set; }
    }
}
