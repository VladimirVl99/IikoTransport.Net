using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Delivery.Restrictions
{
    /// <summary>
    /// Delivery address.
    /// </summary>
    [JsonObject]
    public class DeliveryAddress
    {
        /// <summary>
        /// City.
        /// </summary>
        [JsonProperty(PropertyName = "city", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? City { get; set; }

        /// <summary>
        /// Street.
        /// </summary>
        [JsonProperty(PropertyName = "streetName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? StreetName { get; set; }

        /// <summary>
        /// Street ID.
        /// </summary>
        [JsonProperty(PropertyName = "streetId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? StreetId { get; set; }

        /// <summary>
        /// House.
        /// </summary>
        [JsonProperty(PropertyName = "house", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? House { get; set; }

        /// <summary>
        /// Building.
        /// </summary>
        [JsonProperty(PropertyName = "building", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Building { get; set; }

        /// <summary>
        /// Post index.
        /// </summary>
        [JsonProperty(PropertyName = "index", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Index { get; set; }
    }
}
