using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Webhooks.Filters
{
    /// <summary>
    /// Filter for stop-lists changes.
    /// </summary>
    [JsonObject]
    public class StopListUpdateFilter
    {
        /// <summary>
        /// Flag for updates.
        /// </summary>
        [JsonProperty(PropertyName = "updates", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Updates { get; set; }
    }
}
