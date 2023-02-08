using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders.Customers
{
    /// <summary>
    /// Order waiter.
    /// </summary>
    [JsonObject]
    public class Waiter
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
        /// Phone.
        /// </summary>
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Phone { get; set; }
    }
}
