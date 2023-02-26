using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.LoyaltyAndDiscounts.DiscountsAndPromotions
{
    /// <summary>
    /// Applicable manual discount.
    /// </summary>
    [JsonObject]
    public class CommonDynamicDiscount
    {
        /// <summary>
        /// Manual discount condition identifier.
        /// </summary>
        [JsonProperty(PropertyName = "manualConditionId", Required = Required.Always)]
        public Guid ManualConditionId { get; set; }

        /// <summary>
        /// Discount amount.
        /// </summary>
        [JsonProperty(PropertyName = "Sum", Required = Required.Always)]
        public double Sum { get; set; }
    }
}
