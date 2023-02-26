using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments;
using IikoTransport.Net.Entities.Requests.Orders.Loyalties;
using DiscountsInfo = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Loyalties.DiscountsInfo;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Orders.CreateOrder
{
    /// <summary>
    /// Common information about an order.
    /// </summary>
    [JsonObject]
    public class GeneralOrderCreation
    {
        /// <summary>
        /// Order items.
        /// </summary>
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        public IEnumerable<OrderItem> Items { get; set; } = default!;

        /// <summary>
        /// Combos included in order.
        /// </summary>
        [JsonProperty(PropertyName = "combos", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Combo>? Combos { get; set; }

        /// <summary>
        /// Order payment components.
        /// Type IikoCard allowed from version 7.1.5.
        /// </summary>
        [JsonProperty(PropertyName = "payments", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Payment>? Payments { get; set; }

        /// <summary>
        /// Order tips components.
        /// </summary>
        [JsonProperty(PropertyName = "tips", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Tips>? Tips { get; set; }

        /// <summary>
        /// The string key (marker) of the source (partner - api user) that created the order.
        /// Needed to limit the visibility of orders for external integration.
        /// </summary>
        [JsonProperty(PropertyName = "sourceKey", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? SourceKey { get; set; }

        /// <summary>
        /// Discounts/surcharges.
        /// </summary>
        [JsonProperty(PropertyName = "discountsInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DiscountsInfo? DiscountsInfo { get; set; }

        /// <summary>
        /// Information about Loyalty app.
        /// </summary>
        [JsonProperty(PropertyName = "iikoCard5Info", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IikoCard5Info? IikoCard5Info { get; set; }
    }
}
