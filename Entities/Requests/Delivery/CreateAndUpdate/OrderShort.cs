using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Common.Orders;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DeliveryPoint = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses.DeliveryPoint;
using IikoTransport.Net.Entities.Common.Orders.CreateOrder;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate
{
    /// <summary>
    /// Common information about a delivery order.
    /// </summary>
    [JsonObject]
    public class OrderShort : CommonOrderShort
    {
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
        public new string Phone { get; set; } = default!;

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
    }
}
