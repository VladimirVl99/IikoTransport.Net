using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders.Nomenclature
{
    /// <summary>
    /// Information about a modifier.
    /// </summary>
    [JsonObject]
    public class Modifier
    {
        /// <summary>
        /// Modifier item ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/nomenclature operation.
        /// </summary>
        [JsonProperty(PropertyName = "productId", Required = Required.Always)]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantity.
        /// </summary>
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public double Amount { get; set; }

        /// <summary>
        /// Modifiers group ID (for group modifier). Required for a group modifier.
        /// Can be obtained by https://api-ru.iiko.services/api/1/nomenclature operation.
        /// </summary>
        [JsonProperty(PropertyName = "productGroupId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ProductGroupId { get; set; }

        /// <summary>
        /// Unit price.
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
