using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Guest details.
    /// </summary>
    [JsonObject]
    public class GuestDetails
    {
        /// <summary>
        /// Number of persons in order. This field defines the number of cutlery sets.
        /// </summary>
        [JsonProperty(PropertyName = "count", Required = Required.Always)]
        public int Count { get; set; }

        /// <summary>
        /// Attribute that shows whether order must be split among guests.
        /// </summary>
        [JsonProperty(PropertyName = "splitBetweenPersons", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? SplitBetweenPersons { get; set; }
    }
}
