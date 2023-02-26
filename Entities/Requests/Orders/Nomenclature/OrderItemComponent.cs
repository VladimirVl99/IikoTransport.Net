using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders.Nomenclature
{
    /// <summary>
    /// Information about an order item's component.
    /// </summary>
    [JsonObject]
    public class OrderItemComponent
    {
        /// <summary>
        /// Item ID.
        /// </summary>
        [JsonProperty(PropertyName = "productId", Required = Required.Always)]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "modifier", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Modifier>? Modifiers { get; set; }

        /// <summary>
        /// Price.
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
    }
}
