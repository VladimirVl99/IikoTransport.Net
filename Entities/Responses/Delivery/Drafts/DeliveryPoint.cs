using IikoTransport.Net.Entities.Common.Addresses;
using IikoTransport.Net.Entities.Common.Orders;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Delivery point details.
    /// </summary>
    [JsonObject]
    public class DeliveryPoint : DeliveryPointShort
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
    }
}
