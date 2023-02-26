using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Coupons
{
    /// <summary>
    /// List of non-activated coupons.
    /// </summary>
    [JsonObject]
    public class NotActivatedCouponInfos
    {
        /// <summary>
        /// Not activated coupon.
        /// </summary>
        [JsonProperty(PropertyName = "notActivatedCoupon", Required = Required.Always)]
        public IEnumerable<NotActivatedCoupon> NotActivatedCoupons { get; set; } = default!;
    }
}
