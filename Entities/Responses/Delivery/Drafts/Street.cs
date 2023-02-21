using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Information about a street.
    /// </summary>
    [JsonObject]
    public class Street
    {
        /// <summary>
        /// [ 0 .. 255 ] characters.
        /// Street ID in classifier, e.g., address database.
        /// For using in the Russian Federation only.
        /// </summary>
        [JsonProperty(PropertyName = "classifierId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ClassifierId { get; set; }

        /// <summary>
        /// ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/streets/by_city operation.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// [ 0 .. 60 ] characters.
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// [ 0 .. 60 ] characters.
        /// City name.
        /// </summary>
        [JsonProperty(PropertyName = "city", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? City { get; set; }
    }
}
