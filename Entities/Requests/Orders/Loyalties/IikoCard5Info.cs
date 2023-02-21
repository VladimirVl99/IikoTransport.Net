using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders.Loyalties
{
    /// <summary>
    /// Information about Loyalty app.
    /// </summary>
    [JsonObject]
    public class IikoCard5Info
    {
        /// <summary>
        /// Coupon No. that has to be considered when calculating loyalty program.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Coupon { get; set; }

        /// <summary>
        /// Information about applied manual conditions.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid>? ApplicableManualConditions { get; set; }
    }
}
