using IikoTransport.Net.Entities.Common.Addresses;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRestrictions
{
    /// <summary>
    /// Information about a delivery zone.
    /// </summary>
    [JsonObject]
	public class DeliveryZone
	{
        /// <summary>
        /// Polygon name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Name { get; set; } = default!;

        /// <summary>
        /// A set of points describing a polygon.
        /// </summary>
        [JsonProperty(PropertyName = "coordinates", Required = Required.Always)]
		public IEnumerable<Coordinate> Coordinates { get; set; } = default!;

        /// <summary>
        /// A set of addresses describing a polygon.
        /// </summary>
        [JsonProperty(PropertyName = "addresses", Required = Required.Always)]
		public IEnumerable<DeliveryZoneAddressBinding> Addresses { get; set; } = default!;
	}
}
