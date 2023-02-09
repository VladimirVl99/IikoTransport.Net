using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Write-off type of deletion.
    /// </summary>
    [JsonObject]
    public class RemovalType
    {
        /// <summary>
        /// ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;
    }
}
