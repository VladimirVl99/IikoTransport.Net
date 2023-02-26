using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Delivery.Restrictions
{
    /// <summary>
    /// Common information about a restriction order item.
    /// </summary>
    [JsonObject]
    public class RestrictionsOrderItemShort
    {
        /// <summary>
        /// Product ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Product.
        /// </summary>
        [JsonProperty(PropertyName = "product", Required = Required.Always)]
        public string Product { get; set; } = default!;

        /// <summary>
        /// Amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public double Amount { get; set; }
    }
}
