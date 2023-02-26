using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Programs
{
    /// <summary>
    /// Marketing campaign condition.
    /// </summary>
    [JsonObject]
    public class MarketingCampaignActionConditionBindingInfo
    {
        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Loyalty processing stop after successful execution of binding. So means order of bindings affects.
        /// </summary>
        [JsonProperty(PropertyName = "stopFurtherExecution", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool StopFurtherExecution { get; set; }

        /// <summary>
        /// Marketing actions.
        /// </summary>
        [JsonProperty(PropertyName = "actions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<MarketingCampaignSettingsInfo>? Actions { get; set; }

        /// <summary>
        /// Marketing conditions.
        /// </summary>
        [JsonProperty(PropertyName = "conditions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<MarketingCampaignSettingsInfo>? Conditions { get; set; }
    }
}
