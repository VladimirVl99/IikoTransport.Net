using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.Order;
using IikoTransport.Net.Entities.Responses.Orders.Customers;
using IikoTransport.Net.Entities.Responses.Orders.Discounts;
using IikoTransport.Net.Entities.Responses.Orders.Payments;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Common information about order.
    /// </summary>
    [JsonObject]
    public class OrderShort
    {
        /// <summary>
        /// Guest.
        /// Allowed from version 7.5.2.
        /// </summary>
        [JsonProperty(PropertyName = "customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Customer? Customer { get; set; }

        /// <summary>
        /// Guest phone.
        /// Allowed from version 7.5.2.
        /// </summary>
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string? Phone { get; set; }

        /// <summary>
        /// Order creation date (terminal time zone).
        /// </summary>
        [JsonProperty(PropertyName = "whenCreated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public virtual DateTime? WhenCreated { get; set; }

        /// <summary>
        /// Order closing time (Local for delivery terminal).
        /// </summary>
        [JsonProperty(PropertyName = "whenClosed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenClosed { get; set; }

        /// <summary>
        /// Order amount (after discount or surcharge).
        /// </summary>
        [JsonProperty(PropertyName = "sum", Required = Required.Always)]
        public double Sum { get; set; }

        /// <summary>
        /// Delivery No.
        /// </summary>
        [JsonProperty(PropertyName = "number", Required = Required.Always)]
        public int Number { get; set; }

        /// <summary>
        /// Order source.
        /// </summary>
        [JsonProperty(PropertyName = "sourceKey", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? SourceKey { get; set; }

        /// <summary>
        /// Invoice printing time (guest bill time).
        /// </summary>
        [JsonProperty(PropertyName = "whenBillPrinted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenBillPrinted { get; set; }

        /// <summary>
        /// Concept.
        /// </summary>
        [JsonProperty(PropertyName = "conception", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Conception? Conception { get; set; }

        /// <summary>
        /// Information about order guests.
        /// </summary>
        [JsonProperty(PropertyName = "guestsInfo", Required = Required.AllowNull)]
        public GuestInfo? GuestInfo { get; set; }

        /// <summary>
        /// Order items.
        /// </summary>
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        public IEnumerable<OrderItem> Items { get; set; } = default!;

        /// <summary>
        /// Combo.
        /// </summary>
        [JsonProperty(PropertyName = "combos", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Combo>? Combos { get; set; }

        /// <summary>
        /// Payments.
        /// </summary>
        [JsonProperty(PropertyName = "payments", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<PaymentItem>? Payments { get; set; }

        /// <summary>
        /// Tips.
        /// </summary>
        [JsonProperty(PropertyName = "tips", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Tip>? Tips { get; set; }

        /// <summary>
        /// Discounts.
        /// </summary>
        [JsonProperty(PropertyName = "discounts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<DiscountItem>? Discounts { get; set; }

        /// <summary>
        /// Order type.
        /// </summary>
        [JsonProperty(PropertyName = "orderType", Required = Required.AllowNull)]
        public OrderTypeShort? OrderType { get; set; }

        /// <summary>
        /// ID of the terminal group where the order is located.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupId", Required = Required.Always)]
        public Guid TerminalGroupId { get; set; }

        /// <summary>
        /// The amount of processed payments. null - only for unsupported iikoFront versions.
        /// Allowed from version 7.6.0.
        /// </summary>
        [JsonProperty(PropertyName = "processedPaymentsSum", Required = Required.AllowNull)]
        public double? ProcessedPaymentsSum { get; set; }
    }
}
