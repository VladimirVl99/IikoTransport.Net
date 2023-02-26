using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Coupons
{
    /// <summary>
    /// Information about the specified coupon.
    /// </summary>
    [JsonObject]
    public class CouponInfos
    {
        /// <summary>
        /// Coupon info.
        /// </summary>
        [JsonProperty(PropertyName = "couponInfo", Required = Required.Always)]
        public IEnumerable<CouponInfo> CouponInfo { get; set; } = default!;
    }
}
