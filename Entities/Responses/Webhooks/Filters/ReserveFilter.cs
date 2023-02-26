using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Webhooks.Filters
{
    /// <summary>
    /// Filter for banquets/reserves.
    /// </summary>
    [JsonObject]
    public class ReserveFilter
    {
        /// <summary>
        /// Flag for updates.
        /// </summary>
        [JsonProperty(PropertyName = "updates", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Updates { get; set; }

        /// <summary>
        /// Flag for errors.
        /// </summary>
        [JsonProperty(PropertyName = "errors", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Errors { get; set; }
    }
}
