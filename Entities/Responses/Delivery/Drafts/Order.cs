using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Requests.Orders.Loyalties;
using IikoTransport.Net.Entities.Requests.Orders.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Information about a order draft.
    /// </summary>
    [JsonObject]
    public class Order
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
        /// Order fulfillment date.
        /// Date and time must be local for delivery terminal, without time zone (take a look at example).
        /// If null, order is urgent and time is calculated based on customer settings, i.e. the shortest
        /// delivery time possible. Permissible values: from current day and 60 days on.
        /// </summary>
        [JsonProperty(PropertyName = "completeBefore", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? CompleteBefore { get; set; }

        /// <summary>
        /// [ 8 .. 40 ] characters.
        /// Telephone number.
        /// Must begin with symbol "+" and must be at least 8 digits.
        /// </summary>
        [JsonProperty(PropertyName = "phone", Required = Required.Always)]
        public string Phone { get; set; } = default!;

        /// <summary>
        /// Order type ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/deliveries/order_types operation.
        /// One of the fields required: orderTypeId or orderServiceType.
        /// </summary>
        [JsonProperty(PropertyName = "orderTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? OrderTypeId { get; set; }

        /// <summary>
        /// Order service type.
        /// One of the fields required: orderTypeId or orderServiceType.
        /// Allowed from version 7.0.3.
        /// </summary>
        [JsonProperty(PropertyName = "orderServiceType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderServiceType? OrderServiceType { get; set; }

        /// <summary>
        /// Delivery point details.
        /// Not required in case of customer pickup. Otherwise, required.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryPoint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DeliveryPoint? DeliveryPoint { get; set; }

        /// <summary>
        /// Order comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

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

        /// <summary>
        /// Marketing source (advertisement) ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/marketing_sources operation.
        /// </summary>
        [JsonProperty(PropertyName = "marketingSourceId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? MarketingSourceId { get; set; }

        /// <summary>
        /// Operator ID.
        /// Allowed from version 7.6.3.
        /// </summary>
        [JsonProperty(PropertyName = "operatorId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? OperatorId { get; set; }

        /// <summary>
        /// Order items.
        /// </summary>
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        public IEnumerable<OrderItemDraft> Items { get; set; } = default!;

        /// <summary>
        /// Combos included in order.
        /// </summary>
        [JsonProperty(PropertyName = "combos", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ComboDraft>? Combos { get; set; }

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
