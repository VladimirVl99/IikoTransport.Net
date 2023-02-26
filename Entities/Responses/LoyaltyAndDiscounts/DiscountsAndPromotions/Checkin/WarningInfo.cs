using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Warning about error, not blocking loyalty calculation.
    /// </summary>
    [JsonObject]
    public class WarningInfo
    {
        /// <summary>
        /// Code of an error. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "Code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Code { get; set; }

        /// <summary>
        /// Description of an error. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "Message", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Message { get; set; }
    }
}
