using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Cities
{
    /// <summary>
    /// Common information about a city.
    /// </summary>
    [JsonObject]
    public class CityShort
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
