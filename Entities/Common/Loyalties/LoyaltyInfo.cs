using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Loyalties
{
    /// <summary>
    /// Information about Loyalty app.
    /// </summary>
    [JsonObject]
    public class LoyaltyInfo
    {
        /// <summary>
        /// Coupon No. that was considered when calculating loyalty program.
        /// </summary>
        [JsonProperty(PropertyName = "coupon", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Coupon { get; set; }

        /// <summary>
        /// Information about applied manual conditions.
        /// </summary>
        [JsonProperty(PropertyName = "appliedManualConditions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid>? AppliedManualConditions { get; set; }
    }
}
