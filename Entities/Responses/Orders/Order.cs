using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Responses.Orders.Customers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Common order.
    /// </summary>s
    [JsonObject]
    public class Order : OrderShort
    {
        /// <summary>
        /// Table IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/reserve/available_restaurant_sections operation.
        /// </summary>
        [JsonProperty(PropertyName = "tableIds", Required = Required.Always)]
        public IEnumerable<Guid> TableIds { get; set; } = default!;

        /// <summary>
        /// Enum: "New" "Bill" "Closed" "Deleted".
        /// Order status.
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Order waiter.
        /// </summary>
        [JsonProperty(PropertyName = "waiter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Waiter? Waiter { get; set; }

        /// <summary>
        /// Tab name (only for fastfood terminals group in tab mode).
        /// </summary>
        [JsonProperty(PropertyName = "tabName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? TabName { get; set; }

        /// <summary>
        /// Enum: "Disabled" "Allowed" "Required".
        /// Need to split order between cash registers. Not empty for orders in statuses New or Bill.
        /// </summary>
        [JsonProperty(PropertyName = "splitOrderBetweenCashRegisters", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SplitOrderType? SplitOrderBetweenCashRegisters { get; set; }
    }
}
