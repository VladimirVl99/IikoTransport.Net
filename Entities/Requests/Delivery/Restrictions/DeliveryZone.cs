using Newtonsoft.Json;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses;
using SourceDeliveryZone = IikoTransport.Net.Entities.Responses.Delivery.Restrictions.DeliveryZone;

namespace IikoTransport.Net.Entities.Requests.Delivery.Restrictions
{
    /// <summary>
    /// Information about a delivery zone.
    /// </summary>
    [JsonObject]
    public class DeliveryZone : SourceDeliveryZone
    {
        /// <summary>
        /// A set of points describing a polygon.
        /// </summary>
        [JsonProperty(PropertyName = "coordinates", Required = Required.Always)]
        public new IEnumerable<Coordinate> Coordinates { get; set; }

        /// <summary>
        /// A set of points describing a polygon.
        /// </summary>
        [JsonProperty(PropertyName = "addresses", Required = Required.Always)]
        public new IEnumerable<DeliveryZoneAddressBinding> Addresses { get; set; }


        public DeliveryZone(string name, IEnumerable<Coordinate> coordinates,
            IEnumerable<DeliveryZoneAddressBinding> addresses)
        {
            Name = name;
            Coordinates = coordinates;
            Addresses = addresses;
        }
    }
}
