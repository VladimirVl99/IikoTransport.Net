using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Program free products.
    /// </summary>
    [JsonObject]
    public class FreeProductsGroup
    {
        /// <summary>
        /// Id of action that caused the suggestion.
        /// </summary>
        [JsonProperty(PropertyName = "sourceActionId", Required = Required.Always)]
        public Guid SourceActionId { get; set; }

        /// <summary>
        /// Description for user. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "descriptionForUser", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? DescriptionForUser { get; set; }

        /// <summary>
        /// Products that should be added to order.
        /// </summary>
        [JsonProperty(PropertyName = "products", Required = Required.Always)]
        public IEnumerable<FreeProduct> Products { get; set; } = default!;
    }
}
