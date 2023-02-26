using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Coupons
{
    /// <summary>
    /// List of coupon series in which there are not deleted and not activated coupons.
    /// </summary>
    [JsonObject]
    public class SeriesWithNotActivatedCouponInfos
    {
        /// <summary>
        /// Series with not activated coupons.
        /// </summary>
        [JsonProperty(PropertyName = "seriesWithNotActivatedCoupons", Required = Required.Always)]
        public IEnumerable<SeriesWithNotActivatedCoupons> SeriesWithNotActivatedCoupons { get; set; } = default!;
    }
}
