using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Item deletion details.
    /// </summary>
    [JsonObject]
    public class Deletion
    {
        /// <summary>
        /// Deletion method.
        /// </summary>
        [JsonProperty(PropertyName = "deletionMethod", Required = Required.Always)]
        public DeletionMethod DeletionMethod { get; set; } = default!;
    }
}
