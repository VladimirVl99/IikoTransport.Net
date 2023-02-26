using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Orders
{
    /// <summary>
    /// Delivery point details.
    /// </summary>
    [JsonObject]
    public class DeliveryPointShort
    {
        /// <summary>
        /// [ 0 .. 100 ] characters.
        /// Delivery location custom code in customer's API system.
        /// </summary>
        [JsonProperty(PropertyName = "externalCartographyId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ExternalCartographyId { get; set; }

        /// <summary>
        /// [ 0 .. 500 ] characters
        /// Additional information.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }
    }
}
