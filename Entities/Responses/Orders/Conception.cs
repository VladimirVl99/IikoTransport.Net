using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Concept.
    /// </summary>
    [JsonObject]
    public class Conception
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

        /// <summary>
        /// Code.
        /// </summary>
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public string Code { get; set; } = default!;
    }
}
