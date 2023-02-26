using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.ManualConditions
{
    /// <summary>
    /// Manual conditions.
    /// </summary>
    [JsonObject]
    public class ManualConditionInfos
    {
        /// <summary>
        /// Info about manual conditions.
        /// </summary>
        [JsonProperty(PropertyName = "manualConditions", Required = Required.Always)]
        public IEnumerable<ManualCondition> ManualConditions { get; set; } = default!;
    }
}
