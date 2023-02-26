using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Group contained in combo.
    /// </summary>
    [JsonObject]
    public class ComboGroupMapping
    {
        /// <summary>
        /// Id of combo group.
        /// </summary>
        [JsonProperty(PropertyName = "groupId", Required = Required.Always)]
        public Guid GroupId { get; set; }

        /// <summary>
        /// Id of item, suitable for group.
        /// </summary>
        [JsonProperty(PropertyName = "itemId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ItemId { get; set; }
    }
}
