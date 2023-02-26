using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Requests.Orders.Loyalties;
using IikoTransport.Net.Entities.Requests.Orders.Payments;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Information about a order draft.
    /// </summary>
    [JsonObject]
    public class Order : OrderShort
    {
        /// <summary>
        /// Delivery point details.
        /// Not required in case of customer pickup. Otherwise, required.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryPoint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new DeliveryPoint? DeliveryPoint { get; set; }

        /// <summary>
        /// Customer.
        /// </summary>
        [JsonProperty(PropertyName = "customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new Customer? Customer { get; set; }

        /// <summary>
        /// Guest details. Not equal to the customer who makes an order.
        /// </summary>
        [JsonProperty(PropertyName = "guests", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new GuestDetails? Guests { get; set; }

        /// <summary>
        /// Order items.
        /// </summary>
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        public new IEnumerable<OrderItemDraft> Items { get; set; } = default!;

        /// <summary>
        /// Combos included in order.
        /// </summary>
        [JsonProperty(PropertyName = "combos", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new IEnumerable<ComboDraft>? Combos { get; set; }

        /// <summary>
        /// Order payment components.
        /// Type IikoCard allowed from version 7.1.5.
        /// </summary>
        [JsonProperty(PropertyName = "payments", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new IEnumerable<Payment>? Payments { get; set; }

        /// <summary>
        /// Order tips components.
        /// </summary>
        [JsonProperty(PropertyName = "tips", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new IEnumerable<Tips>? Tips { get; set; }

        /// <summary>
        /// Discounts/surcharges.
        /// </summary>
        [JsonProperty(PropertyName = "discountsInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new DiscountsInfo? DiscountsInfo { get; set; }
    }
}
