using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Coupons
{
    /// <summary>
    /// Common information about a coupon.
    /// </summary>
    [JsonObject]
    public class CouponShortInfo
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

        /// <summary>
        /// Series name. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "seriesName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? SeriesName { get; set; }

        /// <summary>
        /// Series id.
        /// </summary>
        [JsonProperty(PropertyName = "seriesId", Required = Required.Always)]
        public Guid SeriesId { get; set; }
    }
}
