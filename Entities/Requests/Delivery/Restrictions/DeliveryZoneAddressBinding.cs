using Newtonsoft.Json;
using SourceDeliveryZoneAddressBinding
    = IikoTransport.Net.Entities.Responses.Delivery.Restrictions.DeliveryZoneAddressBinding;

namespace IikoTransport.Net.Entities.Requests.Delivery.Restrictions
{
    /// <summary>
    /// Address describing a polygon.
    /// </summary>
    [JsonObject]
    public class DeliveryZoneAddressBinding : SourceDeliveryZoneAddressBinding
    {
        /// <summary>
        /// Range of house numbers in the delivery zone.
        /// </summary>
        [JsonProperty(PropertyName = "houses", Required = Required.Always)]
        public new DeliveryZoneHouse Houses { get; set; }


        public DeliveryZoneAddressBinding(Guid streetId, string postcode,
            DeliveryZoneHouse houses)
        {
            StreetId = streetId;
            Postcode = postcode;
            Houses = houses;
        }
    }
}
