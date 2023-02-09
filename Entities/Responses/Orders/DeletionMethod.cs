using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Deletion method.
    /// </summary>
    [JsonObject]
    public class DeletionMethod
    {
        /// <summary>
        /// ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Write-off type.
        /// </summary>
        [JsonProperty(PropertyName = "removalType", Required = Required.Always)]
        public RemovalType RemovalType { get; set; } = default!;
    }
}
