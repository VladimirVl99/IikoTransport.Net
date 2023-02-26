using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Orders
{
    /// <summary>
    /// Order creation parameters.
    /// </summary>
    [JsonObject]
    public class OrderCreationSettings
    {
        /// <summary>
        /// Timeout in seconds that specifies how much time is given for order to reach iikoFront.
        /// After this time, order is nullified if iikoFront doesn't take it. By default - 8 seconds.
        /// </summary>
        [JsonProperty(PropertyName = "transportToFrontTimeout", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? TransportToFrontTimeout { get; set; }
    }
}
