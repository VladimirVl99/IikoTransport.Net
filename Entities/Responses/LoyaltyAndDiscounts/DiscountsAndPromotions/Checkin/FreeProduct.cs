using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Product that should be added to order.
    /// </summary>
    [JsonObject]
    public class FreeProduct
    {
        /// <summary>
        /// Id of product.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Code of product. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Code { get; set; }

        /// <summary>
        /// Sizes available for that product.
        /// </summary>
        [JsonProperty(PropertyName = "size", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<string>? Size { get; set; }
    }
}
