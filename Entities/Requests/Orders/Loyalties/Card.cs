using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders.Loyalties
{
    /// <summary>
    /// Track of discount card to be applied to order.
    /// </summary>
    [JsonObject]
    public class Card
    {
        /// <summary>
        /// Track of discount card to be applied to order.
        /// </summary>
        [JsonProperty(PropertyName = "track", Required = Required.Always)]
        public string Track { get; set; } = default!;
    }
}
