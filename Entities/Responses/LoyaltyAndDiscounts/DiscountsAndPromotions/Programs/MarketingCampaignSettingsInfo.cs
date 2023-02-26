using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Programs
{
    /// <summary>
    /// Marketing campaign settings.
    /// </summary>
    [JsonObject]
    public class MarketingCampaignSettingsInfo
    {
        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Action/condition settings. Stored as Json. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "settings", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Settings { get; set; }

        /// <summary>
        /// Action/condition type name. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "typeName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? TypeName { get; set; }

        /// <summary>
        /// Hash value of checksum. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "checkSum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CheckSum { get; set; }
    }
}
