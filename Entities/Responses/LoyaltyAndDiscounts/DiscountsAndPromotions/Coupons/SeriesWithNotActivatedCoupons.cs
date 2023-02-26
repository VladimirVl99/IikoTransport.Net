using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Coupons
{
    /// <summary>
    /// Series with not activated coupons.
    /// </summary>
    [JsonObject]
    public class SeriesWithNotActivatedCoupons
    {
        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Number. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "number", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Number { get; set; }
    }
}
