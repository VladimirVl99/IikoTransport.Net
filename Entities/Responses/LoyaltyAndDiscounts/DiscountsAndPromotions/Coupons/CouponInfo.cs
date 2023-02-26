using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Coupons
{
    /// <summary>
    /// Information about a coupon.
    /// </summary>
    [JsonObject]
    public class CouponInfo : CouponShortInfo
    {
        /// <summary>
        /// When activated.
        /// </summary>
        [JsonProperty(PropertyName = "whenActivated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? WhenActivated { get; set; }

        /// <summary>
        /// Is deleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeleted { get; set; }
    }
}
