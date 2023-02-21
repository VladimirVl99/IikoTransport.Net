using IikoTransport.Net.Entities.Common.Addresses;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Delivery point details.
    /// </summary>
    [JsonObject]
    public class DeliveryPoint
    {
        /// <summary>
        /// Delivery address coordinates.
        /// Allowed from version 7.7.3.
        /// </summary>
        [JsonProperty(PropertyName = "coordinates", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Coordinate? Coordinates { get; set; }

        /// <summary>
        /// Order delivery address.
        /// </summary>
        [JsonProperty(PropertyName = "address", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DeliveryAddress? Address { get; set; }

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
