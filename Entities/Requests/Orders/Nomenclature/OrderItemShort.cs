using IikoTransport.Net.Entities.Common.Orders;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Requests.Orders.Nomenclature
{
    /// <summary>
    /// Order item.
    /// </summary>
    [JsonObject]
    public class OrderItemShort
    {
        /// <summary>
        /// ID of menu item.
        /// Can be obtained by https://api-ru.iiko.services/api/1/nomenclature operation.
        /// </summary>
        [JsonProperty(PropertyName = "productId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Main component.
        /// </summary>
        [JsonProperty(PropertyName = "primaryComponent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public OrderItemComponent? PrimaryComponent { get; set; }

        /// <summary>
        /// Minor component.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryComponent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public OrderItemComponent? SecondaryComponent { get; set; }

        /// <summary>
        /// Modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "modifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Modifier>? Modifiers { get; set; }

        /// <summary>
        /// Indivisible modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "commonModifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Modifier>? CommonModifiers { get; set; }

        /// <summary>
        /// Price per item unit. Can be sent different from the price in the base menu.
        /// </summary>
        [JsonProperty(PropertyName = "price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? Price { get; set; }

        /// <summary>
        /// Unique identifier of the item in the order. MUST be unique for the whole system.
        /// Therefore it must be generated with Guid.NewGuid().
        /// If sent null, it generates automatically on iikoTransport side.
        /// </summary>
        [JsonProperty(PropertyName = "positionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderItemType Type { get; set; }

        /// <summary>
        /// [ 0 .. 999.999 ].
        /// Quantity.
        /// </summary>
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public double Amount { get; set; }

        /// <summary>
        /// Size ID. Required if a stock list item has a size scale.
        /// </summary>
        [JsonProperty(PropertyName = "productSizeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ProductSizeId { get; set; }

        /// <summary>
        /// Combo details if combo includes order item.
        /// </summary>
        [JsonProperty(PropertyName = "comboInformation", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ComboInfo? ComboInfo { get; set; }

        /// <summary>
        /// [ 0 .. 255 ] characters.
        /// Comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }
    }
}
