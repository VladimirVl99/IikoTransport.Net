using Newtonsoft.Json;
using IikoTransport.Net.Entities.Requests.Orders.Nomenclature;
using Modifier = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Nomenclature.Modifier;
using ComboInfo = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Nomenclature.ComboInfo;
using OrderItemComponent = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Nomenclature.OrderItemComponent;
using IikoTransport.Net.Entities.Common.Orders;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate
{
    /// <summary>
    /// Order item.
    /// </summary>
    [JsonObject]
    public class OrderItem : OrderItemShort
    {
        /// <summary>
        /// Main component.
        /// </summary>
        [JsonProperty(PropertyName = "primaryComponent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new OrderItemComponent? PrimaryComponent { get; set; }

        /// <summary>
        /// Minor component.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryComponent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new OrderItemComponent? SecondaryComponent { get; set; }

        /// <summary>
        /// Modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "modifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new IEnumerable<Modifier>? Modifiers { get; set; }

        /// <summary>
        /// Indivisible modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "commonModifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new IEnumerable<Modifier>? CommonModifiers { get; set; }

        /// <summary>
        /// Combo details if combo includes order item.
        /// </summary>
        [JsonProperty(PropertyName = "comboInformation", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new ComboInfo? ComboInfo { get; set; }


        /// <summary>
        /// Use for 'Product' type.
        /// </summary>
        /// <param name="productId">ID of menu item.</param>
        /// <param name="amount">Quantity.</param>
        /// <param name="modifiers">Modifiers.</param>
        /// <param name="price">Price per item unit. Can be sent different from the price in the base menu.</param>
        /// <param name="positionId">Unique identifier of the item in the order. MUST be unique for the whole system.
        /// Therefore it must be generated with Guid.NewGuid().
        /// If sent null, it generates automatically on iikoTransport side.</param>
        /// <param name="productSizeId">Size ID. Required if a stock list item has a size scale.</param>
        /// <param name="comboInfo">Combo details if combo includes order item.</param>
        /// <param name="comment">Comment.</param>
        public OrderItem(Guid productId, double amount, IEnumerable<Modifier>? modifiers = null,
            double? price = null, Guid? positionId = null, Guid? productSizeId = null,
            ComboInfo? comboInfo = null, string? comment = null)
        {
            ProductId = productId;
            Amount = amount;
            Modifiers = modifiers;
            Price = price;
            PositionId = positionId;
            ProductSizeId = productSizeId;
            ComboInfo = comboInfo;
            Comment = comment;
            Type = OrderItemType.Product;
        }

        /// <summary>
        /// Use for 'Compound' type.
        /// </summary>
        /// <param name="primaryComponent">Main component.</param>
        /// <param name="amount">Quantity.</param>
        /// <param name="secondaryComponent">Minor component.</param>
        /// <param name="commonModifiers">Indivisible modifiers.</param>
        /// <param name="productSizeId">Size ID. Required if a stock list item has a size scale.</param>
        /// <param name="comboInfo">Combo details if combo includes order item.</param>
        /// <param name="comment">Comment.</param>
        public OrderItem(OrderItemComponent primaryComponent, double amount,
            OrderItemComponent? secondaryComponent = null, IEnumerable<Modifier>? commonModifiers = null,
            Guid? productSizeId = null, ComboInfo? comboInfo = null, string? comment = null)
        {
            PrimaryComponent = primaryComponent;
            Amount = amount;
            SecondaryComponent = secondaryComponent;
            CommonModifiers = commonModifiers;
            ProductSizeId = productSizeId;
            ComboInfo = comboInfo;
            Comment = comment;
            Type = OrderItemType.Compound;
        }

        public OrderItem(OrderItemType type, double amount, Guid? productId, IEnumerable<Modifier>? modifiers = null,
            OrderItemComponent? primaryComponent = null, OrderItemComponent? secondaryComponent = null,
            IEnumerable<Modifier>? commonModifiers = null, double? price = null, Guid? positionId = null,
            Guid? productSizeId = null, ComboInfo? comboInfo = null, string? comment = null)
        {
            Type = type;
            Amount = amount;
            ProductId = productId;
            Modifiers = modifiers;
            PrimaryComponent = primaryComponent;
            SecondaryComponent = secondaryComponent;
            CommonModifiers = commonModifiers;
            Price = price;
            PositionId = positionId;
            ProductSizeId = productSizeId;
            ComboInfo = comboInfo;
            Comment = comment;
        }
    }
}
