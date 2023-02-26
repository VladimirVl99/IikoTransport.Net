using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Loyalties
{
    /// <summary>
    /// Discounts/surcharges.
    /// </summary>
    [JsonObject]
    public class DiscountsInfo
    {
        /// <summary>
        /// Track of discount card to be applied to order.
        /// </summary>
        [JsonProperty(PropertyName = "card", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Card? Card { get; set; }

        /// <summary>
        /// Discounts/surcharges.
        /// Type iikoCard allowed from version 7.4.4.
        /// </summary>
        [JsonProperty(PropertyName = "discounts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Discount>? Discounts { get; set; }
    }
}
