using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Modifier = IikoTransport.Net.Entities.Responses.Orders.Nomenclature.Modifier;
using Size = IikoTransport.Net.Entities.Responses.Orders.Nomenclature.Size;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Information about an order item.
    /// </summary>
    [JsonObject]
    public class OrderItem
    {
        /// <summary>
        /// Item.
        /// </summary>
        [JsonProperty(PropertyName = "product", Required = Required.Always)]
        public ProductShort Product { get; set; } = default!;

        /// <summary>
        /// Modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "modifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Modifier>? Modifiers { get; set; }

        /// <summary>
        /// Price per item unit. Can be sent different from the price in the base menu.
        /// </summary>
        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public double Price { get; set; }

        /// <summary>
        /// Total amount per item including tax, discounts/surcharges.
        /// </summary>
        [JsonProperty(PropertyName = "cost", Required = Required.Always)]
        public double Cost { get; set; }

        /// <summary>
        /// Whether price is predefined.
        /// </summary>
        [JsonProperty(PropertyName = "pricePredefined", Required = Required.Always)]
        public bool PricePredefined { get; set; }

        /// <summary>
        /// Unique identifier of the item in the order and for the whole system.
        /// </summary>
        [JsonProperty(PropertyName = "positionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Tax rate.
        /// </summary>
        [JsonProperty(PropertyName = "taxPercent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? TaxPercent { get; set; }

        /// <summary>
        /// Order item type.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderItemType Type { get; set; }

        /// <summary>
        /// Item cooking status.
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderItemStatus Status { get; set; }

        /// <summary>
        /// Item deletion details. If filled up, item is deleted.
        /// </summary>
        [JsonProperty(PropertyName = "deleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Deletion? Deleted { get; set; }

        /// <summary>
        /// Quantity.
        /// </summary>
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public double Amount { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Printing time (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "whenPrinted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? WhenPrinted { get; set; }

        /// <summary>
        /// Size.
        /// </summary>
        [JsonProperty(PropertyName = "size", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Size? Size { get; set; }

        /// <summary>
        /// Combo details, if order item is part of combo.
        /// </summary>
        [JsonProperty(PropertyName = "comboInformation", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ComboInformation? ComboInformation { get; set; }
    }
}
