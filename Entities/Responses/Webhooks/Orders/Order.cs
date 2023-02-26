using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Common.Loyalties;
using IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Responses.General.Employees;
using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;
using IikoTransport.Net.Entities.Responses.Orders;
using IikoTransport.Net.Entities.Responses.Orders.Customers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Webhooks.Orders
{
    /// <summary>
    /// Information about delivery, table and reserve orders.
    /// </summary>
    [JsonObject]
    public class Order : OrderShort
    {
        /// <summary>
        /// ID of delivery serving as source for splitting by FCRs.
        /// </summary>
        [JsonProperty(PropertyName = "parentDeliveryId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ParentDeliveryId { get; set; }

        /// <summary>
        /// Table IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/reserve/available_restaurant_sections operation.
        /// </summary>
        [JsonProperty(PropertyName = "tableIds", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid> TableIds { get; set; } = default!;

        /// <summary>
        /// Delivery point details. Not required if order type is customer pickup. Otherwise, required.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryPoint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DeliveryPoint? DeliveryPoint { get; set; }

        /// <summary>
        /// Order status.
        /// </summary>
        [JsonProperty(PropertyName = "status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus? Status { get; set; }

        /// <summary>
		/// Delivery cancellation details. Required only if delivery is canceled, i.e. status=Canceled.
		/// </summary>
		[JsonProperty(PropertyName = "cancelInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public CancelInfo? CancelInfo { get; set; }

        /// <summary>
        /// Driver information.
        /// </summary>
        [JsonProperty(PropertyName = "courierInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public CourierInfo? CourierInfo { get; set; }

        /// <summary>
        /// Order fulfillment time (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "completeBefore", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? CompleteBefore { get; set; }

        /// <summary>
        /// Delivery creation time in iikoFront (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "whenCreated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public new DateTime? WhenCreated { get; set; }

        /// <summary>
        /// Delivery confirmation time (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "whenConfirmed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenConfirmed { get; set; }

        /// <summary>
        /// Service printing time (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "whenPrinted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenPrinted { get; set; }

        /// <summary>
        /// Cooking completion time (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "whenCookingCompleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenCookingCompleted { get; set; }

        /// <summary>
        /// Delivery dispatch time (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "whenSended", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenSended { get; set; }

        /// <summary>
        /// Actual delivery time (Local for delivery terminal).
        /// </summary>
        [JsonProperty(PropertyName = "whenDelivered", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenDelivered { get; set; }

        /// <summary>
        /// Order comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Problem flag.
        /// </summary>
        [JsonProperty(PropertyName = "problem", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Problem? Problem { get; set; }

        /// <summary>
        /// Operator that took order.
        /// </summary>
        [JsonProperty(PropertyName = "operator", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Operator? Operator { get; set; }

        /// <summary>
        /// Marketing source.
        /// </summary>
        [JsonProperty(PropertyName = "marketingSource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public MarketingSource? MarketingSource { get; set; }

        /// <summary>
        /// Duration of delivery (in minutes).
        /// </summary>
        [JsonProperty(PropertyName = "deliveryDuration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? DeliveryDuration { get; set; }

        /// <summary>
        /// Ordinal number in route list. Field is filled up at the time of delivery allocation by logistics in iikoFront.
        /// If logistics is not in use, the field is not filled up.
        /// </summary>
        [JsonProperty(PropertyName = "indexInCourierRoute", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? IndexInCourierRoute { get; set; }

        /// <summary>
        /// The time when you need to start cooking an order (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "cookingStartTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? CookingStartTime { get; set; }

        /// <summary>
        /// Order is deleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Moment of time when CloudAPI received the request to create the order (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "whenReceivedByApi", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenReceivedByApi { get; set; }

        /// <summary>
        /// Moment of time when the order first received and saved from iikoFront (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "whenReceivedFromFront", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenReceivedFromFront { get; set; }

        /// <summary>
        /// Tells that this delivery has been moved from terminal group with id "movedFromTerminalGroupId"
        /// by cancelling delivery with deliveryId "movedFromDeliveryId".
        /// Allowed from version 7.5.4.
        /// </summary>
        [JsonProperty(PropertyName = "movedFromDeliveryId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? MovedFromDeliveryId { get; set; }

        /// <summary>
        /// Tells that this delivery has been moved from terminal group with id "movedFromTerminalGroupId"
        /// by cancelling delivery with deliveryId "movedFromDeliveryId".
        /// Allowed from version 7.5.4.
        /// </summary>
        [JsonProperty(PropertyName = "movedFromTerminalGroupId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? MovedFromTerminalGroupId { get; set; }

        /// <summary>
        /// Tells that this delivery has been moved from terminal group with id "movedFromTerminalGroupId"
        /// by cancelling delivery with deliveryId "movedFromDeliveryId".
        /// Allowed from version 7.5.4.
        /// </summary>
        [JsonProperty(PropertyName = "movedFromOrganizationId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? MovedFromOrganizationId { get; set; }

        /// <summary>
        /// ECS info.
        /// Allowed from version 7.7.7.
        /// </summary>
        [JsonProperty(PropertyName = "externalCourierService", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ExternalCourierService? ExternalCourierService { get; set; }

        /// <summary>
        /// Tells that this delivery has been canceled and moved to terminal group with
        /// id iikoTransport.PublicApi.Contracts.Deliveries.Response.Order.Order.MovedToTerminalGroupId.
        /// </summary>
        [JsonProperty(PropertyName = "movedToDeliveryId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? MovedToDeliveryId { get; set; }

        /// <summary>
        /// Tells that this delivery has been canceled and moved to terminal group with id "movedFromTerminalGroupId".
        /// </summary>
        [JsonProperty(PropertyName = "movedToTerminalGroupId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? MovedToTerminalGroupId { get; set; }

        /// <summary>
        /// Tells that this delivery has been canceled and moved to terminal group with id "movedFromTerminalGroupId".
        /// </summary>
        [JsonProperty(PropertyName = "movedToOrganizationId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? MovedToOrganizationId { get; set; }

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

        /// <summary>
        /// Information about Loyalty app. null - only for unsupported POS versions.
        /// </summary>
        [JsonProperty(PropertyName = "loyaltyInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public LoyaltyInfo? LoyaltyInfo { get; set; }
    }
}
