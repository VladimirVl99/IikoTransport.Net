using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Webhooks.Filters
{
    /// <summary>
    /// Filter for personal shift.
    /// </summary>
    [JsonObject]
    public class PersonalShiftFilter
    {
        /// <summary>
        /// Flag for updates.
        /// </summary>
        [JsonProperty(PropertyName = "updates", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Updates { get; set; }
    }
}
