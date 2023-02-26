using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate
{
    /// <summary>
    /// Marketing source.
    /// </summary>
    [JsonObject]
    public class MarketingSource
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
